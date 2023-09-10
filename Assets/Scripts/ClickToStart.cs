using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] GameObject spaceObject;
    // Start is called before the first frame update
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
                return;
            }
            transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.5f * Time.deltaTime);
            spaceObject.transform.position += Vector3.Lerp(Vector3.zero, endpoint, 0.005f * Time.deltaTime);
        }
        Debug.Log(transform.position);
    }
}
