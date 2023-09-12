using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] float batteryDischargeRate = 1.0f;
    [SerializeField] float batteryChargeRate = 1.0f;
    [SerializeField] public float oxygenAmount = 100.00f;
    [SerializeField] public float powerAmount = 100.00f;
    [SerializeField] float oxygenGainAmount = 1.0f;
    [SerializeField] float oxygenLossAmount =1.0f;
    [SerializeField] Image powerON;
    [SerializeField] Image oxygenON;
    [SerializeField] Image temptureON;
    [SerializeField] public float fuelAmount = 100.00f;
    [SerializeField] float fuelGain = 1.0f;
    [SerializeField] float fuelLoss = 1.0f;
    [SerializeField] Collider2D[] colliders;

    float maxFloat = 100.0f;
    public bool fuelbutton = false;
    [SerializeField] Image fuelLight;
    float randomEventTimer = 0;
    bool gamePlaying = false;
    [SerializeField] int randomEventInterval = 30; 

    [SerializeField] float currentTemperature;
    [SerializeField] Image tooltip;
    int WantedTemp = 70;
    
    [SerializeField] GameObject oxygenAlarm;
    [SerializeField] int oxygenAlarmThreshold = 40;
    [SerializeField] int oxygenAlarmThreshold2 = 20;
    [SerializeField] AudioSource oxygenAlarmCaution;
    [SerializeField] AudioClip alarmCaution;

    [SerializeField] GameObject temperatureAlarm;
    [SerializeField] float temperatureAlarmThreshold = 10.0f;
    [SerializeField] float trackedTime;
    [SerializeField] TextMeshProUGUI timeTracked;

    private void Start()
    {
        currentTemperature = 70.0f;
    }
    private void Update()
    {
        if (gamePlaying == true && !tooltip.isActiveAndEnabled)
        {
            powerManager();
            OxygenManager();
            FuelManager();
            TempManager();
            OxygenAlert();
            TempAlarm();
            timeTracker();
            Debugging();

            timeTracked.text = trackedTime.ToString();
        }

    }
    private void FixedUpdate()
    {
        if (gamePlaying == true && !tooltip.isActiveAndEnabled)
        {
            ranndomEvent();
        }
    }

    private void OxygenAlert()
    {
        if (oxygenAmount < oxygenAlarmThreshold)
        {
            oxygenAlarmCaution.PlayOneShot(alarmCaution, .03f);
        }
        
    }

    private void TempAlarm()
    {
        if (currentTemperature < temperatureAlarmThreshold)
        {
            temperatureAlarm.SetActive(true);
        }
        else
        {
            temperatureAlarm.SetActive(false);
        }
    }
    private void ranndomEvent()
    {
        int eventhit = 2;
        int randomNumber = Random.Range(1, 3);
        randomEventTimer += Time.deltaTime;
        if (randomEventTimer > randomEventInterval ) 
        {
            if (randomNumber == eventhit)
            {
                randomEventTimer = 0;
                Debug.Log("RandomCollider disable call");
                DisableRandomCollider();
            }
            randomEventTimer = 0;
        }
    }
    private void TempManager()
    {
        if (temptureON.isActiveAndEnabled)
        {
            if (currentTemperature <= WantedTemp)
            {
                currentTemperature += .2f * Time.deltaTime;
            }
            else if (currentTemperature >= WantedTemp)
            {
                currentTemperature -= .2f * Time.deltaTime;
            }
        }
        else
        {

            currentTemperature -= .2f * Time.deltaTime;
        }
    }
    public int getCurrentTemp()
    {
        // returns current temp
        int tempint = (int)Mathf.Round(currentTemperature);
        return tempint;
    }

    public void SetTemp(int newTemp)
    {
        WantedTemp = newTemp;
    }
    //Collider Logic
    private void DisableRandomCollider()
    {
        int activeColliders = 0;

        foreach (var collider in colliders)
        {
            if (collider.enabled)
            {
                activeColliders++;
            }
        }

        if (activeColliders <= 2)
        {
            return;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, colliders.Length);
        }
        while (!colliders[randomIndex].enabled);

        colliders[randomIndex].enabled = false;
        Debug.Log(randomIndex);
    }

    private void FuelManager()
    {
        // pressing fuel button on ui
        if (fuelbutton && fuelAmount < maxFloat && fuelLight.isActiveAndEnabled)
        {
            fuelAmount += fuelGain * Time.deltaTime;
        }
        else if(!fuelbutton && fuelAmount > 0 && powerON.isActiveAndEnabled)
        {
            fuelAmount -= fuelLoss * Time.deltaTime;
        }
    }

    public void fuelBoolOn()
    {
        fuelbutton = true;
    }

    public void fuelBoolOff()
    {
        fuelbutton = false;
    }    
    private void powerManager()
    {
        
        if (powerON.isActiveAndEnabled && powerAmount < maxFloat && fuelAmount > 0)
        {
            powerAmount += batteryChargeRate * Time.deltaTime;
        }
        else
        {
            if (powerAmount < - 10) 
            {
                powerAmount = -10;
            }
            powerAmount -= batteryDischargeRate * Time.deltaTime;
            
        }
    }
    private void OxygenManager()
    {
        if (oxygenON.isActiveAndEnabled && powerAmount >= 0 && oxygenAmount < maxFloat)
        {
            oxygenAmount += oxygenGainAmount * Time.deltaTime;
        }
        else
        {
            oxygenAmount -= oxygenLossAmount * Time.deltaTime;
        }
    }

    public float GetPowerLevel()
    {
        return powerAmount;
    }
    public float GetOxygenLevel()
    {
        return oxygenAmount;
    }
    public float GetFuelLevel()
    {
        return fuelAmount;
    }


    public void setPlayState(bool State)
    {
        if (State == true)
        {
            gamePlaying = true;
        }
        else
        {
            gamePlaying = false;
        }
    }

    private void timeTracker()
    {
        trackedTime += Time.deltaTime;
    }
    public string getTrackedTime()
    {
        int totalSeconds = (int)Mathf.Round(trackedTime);
        int hours = totalSeconds / 3600;
        int remainderAfterHours = totalSeconds % 3600;

        int minutes = remainderAfterHours / 60;
        int seconds = remainderAfterHours % 60;

        string formatedTime = ($"{hours:00}:{minutes:00}:{seconds:00}");

        return formatedTime;
    }



    private void Debugging()
    {

       //Debug.Log(fuelbutton);
    }
    
}

