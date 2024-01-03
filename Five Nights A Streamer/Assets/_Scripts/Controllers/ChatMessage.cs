using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameTMP, messageTMP;
    [SerializeField] GameObject extendedMessagePanel;
    //[SerializeField] String usernameText, messageText;
    private void SetUsernameText(string username)
    {
        usernameTMP.text = username;
    }

    private void SetMessageText(string message) 
    {
        messageTMP.text = message;
    }

    public void DisplayPanel()
    {
        GameObject[] otherPanels;
        otherPanels = GameObject.FindGameObjectsWithTag("Message Panels");

        foreach (GameObject panel in otherPanels) 
        {
            panel.gameObject.SetActive(false);
        }


        extendedMessagePanel.gameObject.SetActive(true);
    }


}
