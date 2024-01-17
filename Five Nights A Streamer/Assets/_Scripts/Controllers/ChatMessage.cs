using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ChatMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameTMP, messageTMP;
    [SerializeField] GameObject extendedMessagePanel;
    [SerializeField] ChatManager chatManager;
    [SerializeField] GameManager gameManager;
    GameObject chatManagerObject;
    GameObject gameManagerObject;
    GameManager.Spawnable[] spawnables;
    public Vector2 deleteRate = new Vector2(2,3);
    public Vector2 banRate = new Vector2(4,5);

    int deleteMin, deleteMax, banMin, banMax;

    private void Start()
    {
        chatManagerObject = GameObject.FindGameObjectWithTag("Chat Manager");
        chatManager = chatManagerObject.GetComponent<ChatManager>();

        gameManagerObject = GameObject.FindGameObjectWithTag("Game Manager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        deleteMin = (int) deleteRate.x;
        deleteMax = (int) deleteRate.y;

        banMin = (int) banRate.x;
        banMax = (int) banRate.y;

        for (int i = 0; i < gameManager.spawnables.Count; i++)
        {
            spawnables[i] = gameManager.spawnables[i];
        }
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
        return usernameTMP.text.Replace(": ", "");
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

        if (gameObject.tag == "Normal Chat")
        {
            spawnables[0].Weight -= deleteMin;
            spawnables[1].Weight -= deleteMin;
            spawnables[2].Weight -= deleteMin;
            spawnables[3].Weight -= deleteMin;
            spawnables[4].Weight -= deleteMin;
            spawnables[5].Weight -= deleteMin;

            spawnables[6].Weight += deleteMax;
            spawnables[7].Weight += deleteMax;
            spawnables[8].Weight += deleteMax;
            spawnables[9].Weight += deleteMax;
            spawnables[10].Weight += deleteMax;
            spawnables[11].Weight += deleteMax;
            spawnables[12].Weight += deleteMax;

            gameManager.intruderSpawnDelay -= 2;
        }

        else if(gameObject.tag == "Stalker Chat")
        {
            spawnables[0].Weight += deleteMin;
            spawnables[1].Weight += deleteMin;
            spawnables[2].Weight += deleteMin;
            spawnables[3].Weight += deleteMin;
            spawnables[4].Weight += deleteMin;
            spawnables[5].Weight += deleteMin;

            spawnables[6].Weight -= deleteMax;
            spawnables[7].Weight -= deleteMax;
            spawnables[8].Weight -= deleteMax;
            spawnables[9].Weight -= deleteMax;
            spawnables[10].Weight -= deleteMax;
            spawnables[11].Weight -= deleteMax;
            spawnables[12].Weight -= deleteMax;

            gameManager.intruderSpawnDelay += 2;
        }
    }


    public void Ban()
    {
        if(chatManager.usernames.Contains(GetUsername()))
        {
            chatManager.usernames.Remove(chatManager.messages.IndexOf(GetUsername()));
        }

        else if (chatManager.stalkerUsernames.Contains(GetUsername())) 
        {
            chatManager.stalkerMessages.Remove(chatManager.stalkerMessages.IndexOf(GetUsername()));
        }

        Debug.Log("User has been banned");
        SetUsernameText("Banned", Color.red);
        SetMessageText("User banned by moderator", Color.red);
        Destroy(extendedMessagePanel);

        if (gameObject.tag == "Normal Chat")
        {
            spawnables[0].Weight -= banMin;
            spawnables[1].Weight -= banMin;
            spawnables[2].Weight -= banMin;
            spawnables[3].Weight -= banMin;
            spawnables[4].Weight -= banMin;
            spawnables[5].Weight -= banMin;

            spawnables[6].Weight += banMax;
            spawnables[7].Weight += banMax;
            spawnables[8].Weight += banMax;
            spawnables[9].Weight += banMax;
            spawnables[10].Weight += banMax;
            spawnables[11].Weight += banMax;
            spawnables[12].Weight += banMax;
            gameManager.intruderSpawnDelay -= 3;
        }

        else if (gameObject.tag == "Stalker Chat")
        {
            spawnables[0].Weight += banMin;
            spawnables[1].Weight += banMin;
            spawnables[2].Weight += banMin;
            spawnables[3].Weight += banMin;
            spawnables[4].Weight += banMin;
            spawnables[5].Weight += banMin;

            spawnables[6].Weight -= banMax;
            spawnables[7].Weight -= banMax;
            spawnables[8].Weight -= banMax;
            spawnables[9].Weight -= banMax;
            spawnables[10].Weight -= banMax;
            spawnables[11].Weight -= banMax;
            spawnables[12].Weight -= banMax;

            gameManager.intruderSpawnDelay += 3;
        }
    }
}
