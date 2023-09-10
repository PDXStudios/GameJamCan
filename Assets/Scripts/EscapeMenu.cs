using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]GameObject mainUi;
    [SerializeField]GameObject escapeMenuUi;
    private void Update()
    {
        escapeKey();
    }

    public void Resume()
    {
        if (!mainUi.activeSelf)
        {
            mainUi.SetActive(true);
            escapeMenuUi.SetActive(false);
        }
    }
    public void escapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainUi.activeSelf)
            {
                
                mainUi.SetActive(false);
                escapeMenuUi.SetActive(true);
            }
            else
            {
                mainUi.SetActive(true);
                escapeMenuUi.SetActive(false);
            }
        }
    }
}
