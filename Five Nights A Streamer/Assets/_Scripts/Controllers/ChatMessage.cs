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

    private void Start()
    {
        canvasRectTransform = extendedMessagePanel.GetComponent<RectTransform>();

        LockCanvasPosition();
    }
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
        bool activeStatus = extendedMessagePanel.activeInHierarchy;
        GameObject[] otherPanels;
        otherPanels = GameObject.FindGameObjectsWithTag("Message Panel");

        foreach (GameObject panel in otherPanels) 
        {
            panel.SetActive(false);
        }

        extendedMessagePanel.SetActive(!activeStatus);
    }

    private void LockCanvasPosition()
    {
        // Set the anchoredPosition to keep the Canvas in a fixed position
        // For example, let's lock it at (x: 100, y: 100) in the canvas space
        canvasRectTransform.anchoredPosition = new Vector2(100f, 100f);
    }
}
