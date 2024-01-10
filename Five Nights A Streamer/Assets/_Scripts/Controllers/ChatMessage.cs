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

    private void SetUsernameText(string username, Color color)
    {
        usernameTMP.text = username + ": ";
        usernameTMP.color = color;
    }

    private void SetMessageText(string message, Color color) 
    {
        messageTMP.text = usernameTMP.text + message;
        messageTMP.color = color;
    }

    public void DisplayPanel()
    {
        bool activeStatus = extendedMessagePanel.activeInHierarchy;
        GameObject[] otherPanels;
        otherPanels = GameObject.FindGameObjectsWithTag("Message Panel");

        foreach (GameObject panel in otherPanels) 
        {
            panel.SetActive(false);
        }
        extendedMessagePanel.SetActive(!activeStatus);
    }

    public void DeleteMessage()
    {
        Debug.Log("Message has been deleted");
        SetUsernameText("Deleted", Color.red);
        SetMessageText("Message deleted by a moderator", Color.red);
        Destroy(extendedMessagePanel);
    }
}
