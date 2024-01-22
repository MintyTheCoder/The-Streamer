using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

//[RequireComponent(typeof(ChatInfo))]

public class ChatManager : MonoBehaviour
{
    //public static ChatManager _instance;
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages
    [SerializeField] float spawnDelay;
    int messageFreq;
    Vector3 spawnPosition;
    ChatInfo chatInfo;
    public GameObject[] chatMessageList;
    int chatMessagesCount = 0;
    int normalMessageCount = 0;
    [SerializeField] Vector2 messageFreqRange = new Vector2 ();
    [SerializeField] AudioSource alert;

    public ArrayList usernames, messages, stalkerUsernames, stalkerMessages;

    /*private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
    void Start()
    {
        chatInfo = GetComponent<ChatInfo>();
        usernames = chatInfo.usernames;
        messages = chatInfo.messages;
        stalkerUsernames = chatInfo.stalkerUsernames;
        stalkerMessages = chatInfo.stalkerMessages;
        spawnPosition = chatPanel.transform.position + new Vector3(0 , -0.75f, -0.45f);
        AddChatMessage(GetRandomUsername(), GetRandomMessage());
        messageFreq = UnityEngine.Random.Range((int)messageFreqRange.x, (int)messageFreqRange.y);
    }

    IEnumerator DelayMessage()
    {
        yield return new WaitForSeconds(spawnDelay);
        if (normalMessageCount == messageFreq) 
        {
            AddStalkerMessage(GetRandomStalkerUser(), GetRandomStalkerMessage());
            messageFreq = UnityEngine.Random.Range((int) messageFreqRange.x, (int) messageFreqRange.y);
        }

        else
        {
            AddChatMessage(GetRandomUsername(), GetRandomMessage());
        }
    }

    public void AddChatMessage(string username, string message)
    {
        MoveAllMessages();
        GameObject newMessage = Instantiate(chatMessagePrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)), chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.color =  new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        newMessage.tag = "Normal Chat";

        ChatDeleter(newMessage);
        
        chatMessagesCount++;
        normalMessageCount++;

        StartCoroutine(DelayMessage());
        alert.Play();
    }

    public void AddStalkerMessage(string username, string message) 
    {
        MoveAllMessages();
        GameObject newMessage = Instantiate(chatMessagePrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)), chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        newMessage.tag = "Stalker Chat";

        usernameText.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        ChatDeleter(newMessage);

        chatMessagesCount++;
        normalMessageCount = 0;

        StartCoroutine(DelayMessage());
        alert.Play();
    }

    void MoveAllMessages()
    {
        if (chatMessageList != null)
        {
            foreach (GameObject message in GameObject.FindGameObjectsWithTag("Normal Chat"))
            {
                message.transform.position += new Vector3(0, 0.1f, 0);
            }

            foreach (GameObject message in GameObject.FindGameObjectsWithTag("Stalker Chat"))
            {
                message.transform.position += new Vector3(0, 0.1f, 0);
            }
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

    string GetRandomStalkerUser()
    {
        string username = (string) stalkerUsernames[UnityEngine.Random.Range(0, stalkerUsernames.Count)];

        return username;
    }

    string GetRandomStalkerMessage() 
    {
        string message = (string) stalkerMessages[UnityEngine.Random.Range(0, stalkerMessages.Count)];

        return message;
    }
}
