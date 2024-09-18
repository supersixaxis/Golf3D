using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shot : MonoBehaviour
{
    public RectTransform powerBar;
    bool powerActivated = false;
   public GameObject balle;
   bool canShot = true;
   public int shotPowerMultiplier;
   bool canCheckSpeed = false;
   public int nbShots = 0;
   public GameObject Pointer;

   private void Update(){
    if(Input.GetMouseButtonUp(1))
    {
        HandleShot();
    }
    if(balle.GetComponent<Rigidbody>().velocity.magnitude < 0.1f && canCheckSpeed)
    {
        canShot = true;
        GetComponent<Button>().interactable = canShot;
    }
   }
   public void HandleShot(){
    if(canShot)
    {
        if(!powerActivated){
        Pointer.SetActive(true);
        ActivatePowerBar();
    }else 
    {
        canShot = false;
        GetComponent<Button>().interactable = canShot;
      //  SFXManager.Instance.PlaySfxById(3);
        nbShots++;
        Pointer.SetActive(false);
        ShotTheBall();

    }
    }
   
   }
    public void ActivatePowerBar()
    {
        SFXManager.Instance.PlaySfxById(4);
        powerActivated = true;
        StartCoroutine("AnimatePowerBar");
    }

    public void ShotTheBall()
    {
        SFXManager.Instance.PlaySfxById(1);
        StopAllCoroutines();
        float shotPower = powerBar.localScale.x * shotPowerMultiplier;
        balle.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotPower);
        powerActivated = false;
        StartCoroutine("ActivateSpeedCheck");
    }
    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1);
        canCheckSpeed = true;
    }
    IEnumerator AnimatePowerBar(){
        float val = 0.1f;
        while(powerActivated){
            yield return new WaitForSeconds(0.15f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y,powerBar.localScale.z);
            if(powerBar.localScale.x < 0.2f){
                val = -0.1f;
            }
            if(powerBar.localScale.x > 0.9f){
                val = 0.1f;
            }
        }
    }
}
