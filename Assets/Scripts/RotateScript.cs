using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
   public Vector2 rotation;
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
