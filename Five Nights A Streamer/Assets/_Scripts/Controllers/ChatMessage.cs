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
    private RectTransform canvasRectTransform;

    private void SetUsernameText(string username)
    {
        usernameTMP.text = username + ": ";
    }

    private void SetMessageText(string message) 
    {
        messageTMP.text = usernameTMP.text + message;
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
        SetUsernameText("Deleted");
        SetMessageText("Message was deleted by a moderator");
    }
}
