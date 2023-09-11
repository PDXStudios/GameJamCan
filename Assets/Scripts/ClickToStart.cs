using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickToStart : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject spaceObject;
    [SerializeField] Button clickStartButton;
    Vector3 endpoint = new Vector3 (0,1080,0);
    bool atEnd = true;


    public void ClickStart()
    {
        atEnd = false;
        gameController.setPlayState(true);
    }

    public void Update()
    {
        if (atEnd == false) 
        {
            if (transform.position.y >= 1080)
            {
                atEnd = true;
                transform.position = new Vector3(960.00f, 1080.0f, 0f);
                return;
            }
            transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.35f * Time.deltaTime);
            spaceObject.transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.007f * Time.deltaTime);
            // transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.25f * Time.deltaTime);
            clickStartButton.gameObject.SetActive(false);
        }
    }
}
