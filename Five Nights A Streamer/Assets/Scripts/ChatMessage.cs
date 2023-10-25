using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameObject;
    [SerializeField] TextMeshProUGUI chatMessageObject;
    
    public ChatMessage(string username, string chatMessage)
    {
        usernameObject.text = username;
        chatMessageObject.text = username+ ": " + chatMessage;


    }
}
