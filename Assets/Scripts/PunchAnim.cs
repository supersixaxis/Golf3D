using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnim : MonoBehaviour
{

    void Start()
    {
        iTween.PunchScale(gameObject, iTween.Hash(
            "looptype", iTween.LoopType.loop,
            "amount", new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f, transform.localScale.z)
        ));
    }

}
