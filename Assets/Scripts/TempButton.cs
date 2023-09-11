using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempButton : MonoBehaviour
{
    [SerializeField] Image upTemp;
    [SerializeField] Image downTemp;
    [SerializeField] TextMeshProUGUI currentTemp;
    [SerializeField] TextMeshProUGUI setTemp;

    int tempCur;
    int tempSet;


    private void Start()
    {
        tempCur = 70;
        tempSet = 70;
    }

    private void Update()
    {
        currentTemp.text = tempCur.ToString();
        setTemp.text = tempSet.ToString();

    }

    public void IncreaseTemp()
    {
        currentTemp.gameObject.SetActive(false);
        setTemp.gameObject.SetActive(true);
        tempSet++;
        
    }

    public void DecreaseTemp()
    {
        currentTemp.gameObject.SetActive(false);
        setTemp.gameObject.SetActive(true);
        tempSet--;
        
    }

    public void SetTemp()
    {
        currentTemp.gameObject.SetActive(true);
        setTemp.gameObject.SetActive(false);
    }
}
