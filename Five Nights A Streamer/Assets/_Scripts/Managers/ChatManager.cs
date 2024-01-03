using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public GameObject chatMessagePrefab;
    public Transform chatPanel; // The parent transform for chat messages
    Vector3 spawnPosition = new Vector3(-15.3f, 68 , 0);
    ChatData _chatData;
    public GameObject[] chatMessageList;
    int chatMessagesCount = 0;

    private struct ChatData{
        public string[] Usernames;
        public string[] Messages;
    }

    void Awake()
    {
        // arrayScript = GameObject.Find("Arrays").GetComponent<Arrays>();
        
        // userNames = arrayScript.userNames;
        // chatMessages = arrayScript.chatMessages;

        string json = File.ReadAllText(Application.dataPath + "/_Scripts/ChatInfo.json");
        _chatData = JsonUtility.FromJson<ChatData>(json);
        AddChatMessage(GetRandomUsername(), GetRandomMessage());

    }

    IEnumerator DelayMessage()
    {
        //while (true)
        //{
            //yield return new WaitForSeconds(Random.Range(5,7));
            yield return new WaitForSeconds(1.5f);
            AddChatMessage(GetRandomUsername(), GetRandomMessage());
        //}
       
    }

    void Start()
    {

    }
    public void AddChatMessage(string username, string message)
    {
        MoveAllMessages();

        GameObject newMessage = Instantiate(chatMessagePrefab, spawnPosition, Quaternion.identity, chatPanel);
        TextMeshProUGUI usernameText = newMessage.transform.Find("Username").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI messageText = newMessage.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        usernameText.color =  new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        usernameText.text = username + ": ";
        messageText.text = username + ": " + message;

        //Debug.Log("Spawned Message");

        ChatDeleter(newMessage);
        
        chatMessagesCount++;

        StartCoroutine(DelayMessage());
    }

    void MoveAllMessages()
    {
        if (chatMessageList != null)
        {
            foreach (GameObject message in GameObject.FindGameObjectsWithTag("Message"))
            {
                message.transform.position += new Vector3(0, 10, 0);
            }

            GameObject[] messages = GameObject.FindGameObjectsWithTag("Message");
        }  
    }

    private void ChatDeleter(GameObject newMessage)
    {
        if (chatMessagesCount < chatMessageList.Length)
        {
            chatMessageList[chatMessagesCount] = newMessage;
        }

        else
        {
            Destroy(chatMessageList[0]);
            for (int i = 0; i < chatMessageList.Length - 1; i++)
            {
                chatMessageList[i] = chatMessageList[i + 1];
                //Debug.Log("Object Moved Up To Index " + i);
            }
            chatMessageList[chatMessageList.Length - 1] = newMessage;
        }
    }

    string GetRandomUsername()
    {
        string username = _chatData.Usernames[UnityEngine.Random.Range(0,_chatData.Usernames.Length)];

        return username;
    }

    string GetRandomMessage()
    {
        string message = _chatData.Messages[UnityEngine.Random.Range(0, _chatData.Messages.Length)];
        
        return message;
    }
}
