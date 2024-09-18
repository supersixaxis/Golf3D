using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public GameObject winParticles;
    public Text text;
    public Shot shotScript;
    public GameObject panelFin;
    public Transform cubeFin;
    public GameObject camZoom;
    bool canZoom = true;

    private void Start()
    {
        cubeFin = GameObject.Find("Cube fin").transform;
    }

    public void Update()
    {   
        if (camZoom)
        {
             if(Vector3.Distance(transform.position, cubeFin.position) < 2f)
        {
            if(canZoom)
            {
                 canZoom = false;
                 camZoom.SetActive(true);
                 camZoom.GetComponent<DisableZoom>().ForceDisable();
            }
           
        }
        else{
            camZoom.SetActive(false);
            canZoom = true;
        }
    }
        }
       

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fall"){
            SFXManager.Instance.PlaySfxById(2);
            StartCoroutine("LoadLevelAfterSeconds");
        }
        if(other.gameObject.tag == "fin"){
            int score = (10 - shotScript.nbShots) * 100;
            if(score < 0) score = 0;
            GameManager.Instance.score += score;
            Instantiate(winParticles, transform.position, Quaternion.identity);
            SFXManager.Instance.PlaySfxById(0);
            panelFin.SetActive(true);
        }
        if(other.gameObject.tag == "bonus")
        {
            Destroy(other.gameObject);
            SFXManager.Instance.PlaySfxById(3);
            GameManager.Instance.bonusCount++;
        }
    }
    IEnumerator LoadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
