using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] GameObject usernameObj, messageObj;
    [SerializeField] TextMeshProUGUI usernameText, messageText;

    private void Update()
    {
        
    }
    private void setUsernameText(string username)
    {
        usernameText.text = username;
    }


}
