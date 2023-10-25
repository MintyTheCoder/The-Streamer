using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting; 

public class ChatManager : MonoBehaviour
{
    public TextAsset jsonFile;
    Vector3[] chatPositions = new Vector3[10];

    float i = 0f;
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages

    private void Start()
    {
        userNames = JsonUtility.FromJson(jsonFile.text);
        AddChatMessage(GetRandomUsername(), GetRandomMessage());
    }
    public void AddChatMessage(string username, string message)
    {
        GameObject newMessage = Instantiate(chatMessagePrefab, chatPanel.transform.position + new Vector3(0,i,0) , Quaternion.identity, chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        Debug.Log("Test");

        i += 20f;

        // Optionally, you can add animation logic here

        // You may want to limit the number of messages displayed
        // and remove older ones if the chat panel becomes too crowded
    }

    private void Update()
    {
        
    }

    public void storeChatPositions()
    { 
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
