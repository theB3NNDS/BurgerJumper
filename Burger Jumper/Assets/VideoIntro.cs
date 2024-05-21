using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "TitleScreen";
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
