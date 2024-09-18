using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
  public static SFXManager _instance;
  public static SFXManager Instance
  {
    get
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<SFXManager>();
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
  public AudioClip[] sfx;
  public AudioSource aSource;

  public void PlaySfxById(int id){
    aSource.PlayOneShot(sfx[id]);
  }
}
