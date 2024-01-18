using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    GameObject otherArea;

    public void OnTeleport(GameObject otherArea)
    {
        gameObject.SetActive(false);
        otherArea.SetActive(true);
    }
}
