using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroHandler : MonoBehaviour
{
    private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
	vp.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
	
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
	SceneManager.LoadScene("MainMenu");
    }
}
