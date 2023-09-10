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
        if (escapeMenuUi.activeSelf)
        {
            escapeMenuUi.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    public void escapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escapeMenuUi.activeSelf)
            {
                
                escapeMenuUi.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {

                escapeMenuUi.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
}
