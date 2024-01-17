using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

//[RequireComponent(typeof(ChatInfo))]

public class ChatManager : MonoBehaviour
{
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages
    [SerializeField] float spawnDelay;
    Vector3 spawnPosition;
    ChatInfo chatInfo;
    public GameObject[] chatMessageList;
    int chatMessagesCount = 0;

    public ArrayList usernames, messages, stalkerUsernames, stalkerMessages;

    void Start()
    {
        chatInfo = GetComponent<ChatInfo>();
        usernames = chatInfo.usernames;
        messages = chatInfo.messages;
        stalkerUsernames = chatInfo.stalkerUsernames;
        stalkerMessages = chatInfo.stalkerMessages;
        spawnPosition = chatPanel.transform.position + new Vector3(0 , -0.95f, -0.55f);
        //AddChatMessage();
        AddChatMessage(GetRandomUsername(), GetRandomMessage());
    }

    /// <summary>
    /// Searches through the list and "bans" the user
    /// </summary>
    /// <param name="user">string that represents a in game chatter</param>
    /*public void BanUser(string user)
    {
        string chatInfo = File.ReadAllText(Application.persistentDataPath + "/ChatInfoCopy.json");
        _chatData = JsonUtility.FromJson<ChatData>(chatInfo);

        for (int i = 0; i < _chatData.Usernames.Count; i++)
        {
            if (user.Equals(_chatData.Usernames[i]))
            {
                _chatData.Usernames.RemoveAt(i);
            }
        }

        string json = JsonUtility.ToJson(_chatData);
        File.WriteAllText(Application.persistentDataPath + "/ChatInfoCopy.json", json);
    }*/

    IEnumerator DelayMessage()
    {
        yield return new WaitForSeconds(spawnDelay);
        AddChatMessage(GetRandomUsername(), GetRandomMessage());
    }

    public void AddChatMessage(string username, string message)
    {
        MoveAllMessages();
        //Instantiate(chatMessagePrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)), chatPanel);
        GameObject newMessage = Instantiate(chatMessagePrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)), chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.color =  new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        ChatDeleter(newMessage);
        
        chatMessagesCount++;

        StartCoroutine(DelayMessage());
    }

    void MoveAllMessages()
    {
        if (chatMessageList != null)
        {
            foreach (GameObject message in GameObject.FindGameObjectsWithTag("Message"))
            {
                message.transform.position += new Vector3(0, 0.1f, 0);
            }

            GameObject[] messages = GameObject.FindGameObjectsWithTag("Message");
        }  
    }

    private void ChatDeleter(GameObject newMessage)
    {
        if (chatMessagesCount < chatMessageList.Length)
        {
            chatMessageList[chatMessagesCount] = newMessage;
        }

        else
        {
            Destroy(chatMessageList[0]);
            for (int i = 0; i < chatMessageList.Length - 1; i++)
            {
                chatMessageList[i] = chatMessageList[i + 1];
            }
            chatMessageList[chatMessageList.Length - 1] = newMessage;
        }
    }

    string GetRandomUsername()
    {
        string username = (string) usernames[UnityEngine.Random.Range(0, usernames.Count)];

        return username;
    }

    string GetRandomMessage()
    {
        string message = (string) messages[UnityEngine.Random.Range(0, messages.Count)];

        return message;
    }


}
