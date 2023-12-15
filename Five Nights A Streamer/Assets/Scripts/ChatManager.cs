using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ChatManager : MonoBehaviour
{
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages
    Arrays arrayScript;

    Vector3 spawnPosition = new Vector3(0, -275, -50);

    string[] userNames;
    string[] chatMessages;
    public GameObject[] chatMessageList;

    int chatMessagesCount = 0;

    private void Awake()
    {
        arrayScript = GameObject.Find("Arrays").GetComponent<Arrays>();

        userNames = arrayScript.userNames;
        chatMessages = arrayScript.chatMessages;

        AddChatMessage(GetRandomUsername(), GetRandomMessage());

    }

    IEnumerator DelayMessage()
    {
        //while (true)
        //{
            //yield return new WaitForSeconds(Random.Range(5,7));
            yield return new WaitForSeconds(1.5f);
            AddChatMessage(GetRandomUsername(), GetRandomMessage());
        //}
       
    }

    private void Start()
    {
        //AddChatMessage(GetRandomUsername(), GetRandomMessage());     
    }
    public void AddChatMessage(string username, string message)
    {
        MoveAllMessages();

        GameObject newMessage = Instantiate(chatMessagePrefab, spawnPosition, Quaternion.identity, chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.color =  new Color(Random.value, Random.value, Random.value);
        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        Debug.Log("Spawned Message");

        ChatDeleter(newMessage);
        
        chatMessagesCount++;

        StartCoroutine(DelayMessage());
    }

    void MoveAllMessages()
    {
        foreach(GameObject message in GameObject.FindGameObjectsWithTag("Message"))
        {
            message.transform.position += new Vector3(0, 15, 0);
        }

        GameObject[] messages = GameObject.FindGameObjectsWithTag("Message");
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
                Debug.Log("Object Moved Up To Index " + i);
            }
            chatMessageList[chatMessageList.Length - 1] = newMessage;
        }
    }

    string GetRandomUsername()
    {
        string username = userNames[Random.Range(0,userNames.Length)];

        return username;
    }

    string GetRandomMessage()
    {
        string message = chatMessages[Random.Range(0, chatMessages.Length)];

        return message;
    }
}
