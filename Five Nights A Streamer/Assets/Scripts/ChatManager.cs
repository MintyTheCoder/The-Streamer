using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputRemoting;

public class ChatManager : MonoBehaviour
{
    Vector3[] chatPositions = new Vector3[10];

    float i = 0f;
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages
    public Arrays arrayScript;

    string[] userNames;
    string[] chatMessages;
    public GameObject[] chatMessageList = new GameObject[20];

    int chatMessagesCount = 0;

    private void Awake()
    {
        arrayScript = GameObject.Find("Arrays").GetComponent<Arrays>();

        userNames = arrayScript.userNames;
        chatMessages = arrayScript.chatMessages;

        StartCoroutine(DelayMessage());

    }

    IEnumerator DelayMessage()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5,7));
            AddChatMessage(GetRandomUsername(), GetRandomMessage());
        }
       
    }

    private void Start()
    {
        AddChatMessage(GetRandomUsername(), GetRandomMessage());     
    }
    public void AddChatMessage(string username, string message)
    {
        //method for moving all messages down
        MoveAllMessages();

        GameObject newMessage = Instantiate(chatMessagePrefab, chatPanel.transform.position, Quaternion.identity, chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        Debug.Log("Spawned Message");

        //chatMessageList[chatMessagesCount] = newMessage;
        //chatMessagesCount++;

        // Optionally, you can add animation logic here

        // You may want to limit the number of messages displayed
        // and remove older ones if the chat panel becomes too crowded
    }

    void MoveAllMessages()
    {
        foreach(GameObject message in GameObject.FindGameObjectsWithTag("Message"))
        {
            message.transform.position -= new Vector3(0, 20, 0);
        }

        GameObject[] messages = GameObject.FindGameObjectsWithTag("Message");

        /*for(int i; i < messages.Length - 1; i++)
        {
            messages[i].transform.position -= new Vector3(0, messages[i+1], 0);
        }*/
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
