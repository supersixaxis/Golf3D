using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PanelFin : MonoBehaviour
{
     public Text textScore;

    private void Start()
    {
        SetTotalScore();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToNextLevel()
    {
          int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
          UnlockNextLevel(nextLevel);
            if(nextLevel < 11)
            {
                SceneManager.LoadScene(nextLevel); // level suivant
            }
            else
            {
                 SceneManager.LoadScene(0); // Retour menu
            }
    }

    public void UnlockNextLevel(int lvl)
    {
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastlevel");
        if(lvl > lastUnlockedLevel)
        {
             PlayerPrefs.SetInt("lastlevel", lvl);
        }
       
    }

    public void SetTotalScore()
    {
        textScore.text = "Votre score total : " + GameManager.Instance.score;
    }


}
