using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    Vector3[] chatPositions;
    GameObject chatMessage;
    public static string[] userNames = { "ty", "monty", "will" };
    string[] chatMessages = { "Hi", "Hello", "Good Evening" };
    ChatMessage[] allMessages = new ChatMessage[userNames.Length];
    ChatMessage[] currentChatMessages = new ChatMessage[10];
    

    // Start is called before the first frame update
    void Start()
    {   
        for (int i =0; i < allMessages.Length; i++)
        {
            allMessages[i] = new ChatMessage(GetRandomUsername(), GetRandomMessage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnChatMessage()
    {
        Destroy(currentChatMessages[0]);
        for (int i = 0; i < currentChatMessages.Length; i++) 
        {
            if (i == chatMessages.Length - 1)
            {
                currentChatMessages[i - 1] = currentChatMessages[i];
               //Avoid the error from index 29 trying to access index 30 which doesnt exist
            }

            else
            {
                currentChatMessages[i] = currentChatMessages[i + 1];
            }
        }

        currentChatMessages[currentChatMessages.Length - 1] = allMessages[Random.Range(0, allMessages.Length)];
    }

    string GetRandomUsername()
    {
        string username = userNames[Random.Range(0,userNames.Length)];

        return username;
    }

    string GetRandomMessage()
    {
        string message = chatMessages[Random.Range(0, userNames.Length)];

        return message;
    }
}
