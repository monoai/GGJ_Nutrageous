using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager: MonoBehaviour
{

    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject Duster;

    public void Pause()
    {
        PauseScreen.SetActive(true);
        //Time.timeScale = 0f; //not sure if this is still relevant
        PauseButton.SetActive(false);
        Duster.SetActive(false);
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        //Time.timeScale = 1f; //not sure if this is still relevant
        PauseButton.SetActive(true);
        Duster.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        //Time.timeScale = 1f; //not sure if this is still relevant
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit(); 
    }
  
}
