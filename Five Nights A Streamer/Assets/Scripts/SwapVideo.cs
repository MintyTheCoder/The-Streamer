using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwapVideo : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip video;
    void Start()
    {
      videoPlayer = GetComponent<VideoPlayer>();
      videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.clip = video;
        Debug.Log("Video Switched");
    }


}
