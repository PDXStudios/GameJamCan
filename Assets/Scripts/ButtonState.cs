using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlipSwitchButton : MonoBehaviour
{
    [SerializeField] Image On, Off;
    [SerializeField] Image Image;
    [SerializeField] GameObject gameController;

    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        ChangeButtonImage();
    }

    public void ToggleState()
    {
        isOn = !isOn;
        ChangeButtonImage();
    }
    void ChangeButtonImage()
    {

        On.gameObject.SetActive(isOn);
        Off.gameObject.SetActive(!isOn);
        
    }
}
