using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMultipleMusic : MonoBehaviour
{
    GameObject[] go;
    void Start()
    {
       go = GameObject.FindGameObjectsWithTag("music");
       if(go.Length > 1)
       {
        Destroy(go[1]);
       }
    }


}
