using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager _instance;
  public static GameManager Instance
  {
    get
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<GameManager>();
        }
        return _instance;
    }


  }    
  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
  }
  public int score = 0;
  public int bonusCount = 0;
}
