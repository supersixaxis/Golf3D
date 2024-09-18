using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
 
    void Start()
    {
       int lvl = PlayerPrefs.GetInt("lastlevel");
       int thisLvl = int.Parse(gameObject.name);
     //  print(lvl + " - " + thisLvl); 
       if(thisLvl <= lvl)
       {
        GetComponent<Button>().interactable = true;
       }
    }


}
