using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickToStart : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject spaceObject;
    [SerializeField] Button clickStartButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip beep;
    bool atEnd = true;
    int screen = Screen.height;

    public void ClickStart()
    {
        audioSource.PlayOneShot(beep);
        atEnd = false;
        gameController.setPlayState(true);
        
    }

    public void Update()
    {
        if (atEnd == false) 
        {
           
            if (transform.position.y >= Screen.height)
            {
                atEnd = true;
                return;
                
            }
            transform.position += Vector3.Lerp(Vector3.zero, new Vector3 (0, Screen.height ,0), 0.35f * Time.deltaTime);
            spaceObject.transform.position += Vector3.Lerp(Vector3.zero, new Vector3(0, Screen.height, 0), 0.007f * Time.deltaTime);
            // transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.25f * Time.deltaTime);
            
            clickStartButton.gameObject.SetActive(false);
            
        }
    }
}
