using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
       bool isPaused = false;
       public GameObject pauseMenu;

    public void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
       public void SetPauseState()
       {
        SFXManager.Instance.PlaySfxById(3);
        if(!isPaused)
        {
            pauseMenu.SetActive(true);
           Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
         isPaused = !isPaused;
       }
       public void QuitApp()
       {
        Application.Quit();
       }
}

