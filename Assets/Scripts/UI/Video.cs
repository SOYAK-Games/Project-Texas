using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class Video : MonoBehaviour
{
    [SerializeField]
    VideoPlayer VideoIntro;
    
    void Start()
    {
        VideoIntro.loopPointReached += VideoFinish;
    }

    void VideoFinish(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }


}
