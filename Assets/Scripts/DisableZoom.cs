using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableZoom : MonoBehaviour
{

    void Start()
    {
      ForceDisable();
    }

    public void ForceDisable()
    {
           StartCoroutine("DisableThisCam");
    }
  IEnumerator DisableThisCam()
  {
    yield return new WaitForSeconds(2);
    this.gameObject.SetActive(false);  
  }
  
}
