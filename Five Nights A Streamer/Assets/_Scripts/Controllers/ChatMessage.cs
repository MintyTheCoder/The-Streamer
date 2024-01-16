using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameTMP, messageTMP;
    [SerializeField] GameObject extendedMessagePanel;
    [SerializeField] ChatManager chatManager;
    GameObject chatManagerObject;

    private void Start()
    {
        //chatManagerObject = GameObject.FindGameObject("Chat Manager");
        chatManagerObject = GameObject.FindGameObjectWithTag("Chat Manager");
        chatManager = chatManagerObject.GetComponent<ChatManager>();
    }

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

    private string GetUsername()
    {
        return usernameTMP.text;
    }

    public void DisplayPanel()
    {
        if (extendedMessagePanel != null) 
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
    }

    public void DeleteMessage()
    {
        Debug.Log("Message has been deleted");
        SetUsernameText("Deleted", Color.red);
        SetMessageText("Message deleted by a moderator", Color.red);
        Destroy(extendedMessagePanel);
    }


    public void Ban()
    {
        //chatManager.BanUser(GetUsername());
        DeleteMessage();
    }
}
