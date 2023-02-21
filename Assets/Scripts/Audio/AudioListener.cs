using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    public void PlayAudio(string name)
    {
        if (name != null)
        {
            AudioManager.instance.Play(name);
        }
    }
}
