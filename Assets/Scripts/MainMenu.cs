using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //options button didnt need a script so see button for info

    public void QuitGame()
    {
        Debug.Log("Quit was called From the ui menu :)");
        Application.Quit();
    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
