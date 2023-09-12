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
    [SerializeField] float oxygenLossAmount = 1.0f;
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
    [SerializeField] AudioSource oxygenAlarmUrgent;
    [SerializeField] AudioClip alarmCaution;
    [SerializeField] AudioClip alarmUrgent;
    private bool hasPlayedCaution = false;
    private bool hasStartedLoop = false;
    private bool alarmSilenced = false;
    [SerializeField] Image oxygenCaution;
    [SerializeField] Image oxygenUrgent;

    [SerializeField] GameObject temperatureAlarm;
    [SerializeField] float temperatureAlarmThreshold = 50;
    [SerializeField] float temperatureAlarmThreshold2 = 20;
    [SerializeField] AudioSource tempAlarmCaution;
    [SerializeField] AudioSource tempAlarmUrgent;
    [SerializeField] AudioClip tempAlarmCautionClip;
    [SerializeField] AudioClip tempAlarmUrgentClip;
    private bool hasPlayedTempCaution = false;
    private bool hasStartedTempLoop = false;
    private bool alarmTempSilenced = false;
    [SerializeField] Image tempCaution;
    [SerializeField] Image tempUrgent;

    [SerializeField] float trackedTime;
    [SerializeField] TextMeshProUGUI timeTracked;
    [SerializeField] TextMeshProUGUI timeTrackedGO;

    [SerializeField] Image uiErrorHandler;
    [SerializeField] Image uiGameOverHandler;

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
            gameOver();


        }
        timeTracked.text = getTrackedTime();
        timeTrackedGO.text = getTrackedTime();

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
        if (oxygenAmount < oxygenAlarmThreshold2)
        {
            if (!hasStartedLoop && !alarmSilenced)
            {
                oxygenUrgent.gameObject.SetActive(true);
                oxygenAlarmUrgent.loop = true;
                oxygenAlarmUrgent.clip = alarmUrgent;
                oxygenAlarmUrgent.Play();
                hasStartedLoop = true;
            }
        }
        else if (oxygenAmount < oxygenAlarmThreshold)
        {
            if (!hasPlayedCaution)
            {
                oxygenAlarmCaution.PlayOneShot(alarmCaution);
                hasPlayedCaution = true;
                oxygenCaution.gameObject.SetActive(true);
            }
        }
        else
        {
            ResetAlarms();
            oxygenCaution.gameObject.SetActive(false);
            oxygenUrgent.gameObject.SetActive(false);
        }

    }

    private void TempAlarm()
    {
        if (currentTemperature < temperatureAlarmThreshold2)
        {
            if(!hasStartedTempLoop && !alarmTempSilenced)
            {
                tempUrgent.gameObject.SetActive(true); ;
                tempAlarmUrgent.loop = true;
                tempAlarmUrgent.clip = tempAlarmUrgentClip;
                tempAlarmUrgent.Play();
                hasStartedTempLoop = true;
            }
        }
        else if (currentTemperature <temperatureAlarmThreshold)
        {
            if(!hasPlayedTempCaution)
            {
                tempAlarmCaution.PlayOneShot(tempAlarmCautionClip);
                hasPlayedCaution = true;
                tempCaution.gameObject.SetActive(true);
            }
        }
        else
        {
            ResetTempAlarms();
            tempCaution.gameObject.SetActive(false);
            tempUrgent.gameObject.SetActive(false);
        }
    }

    public void SilenceOxygenAlarm()
    {
        if (hasStartedLoop)
        {
            oxygenAlarmUrgent.Stop();
            alarmSilenced = true;
        }
    }

    public void SilenceTempAlarn()
    {
        if(hasStartedTempLoop)
        {
            tempAlarmUrgent.Stop();
            alarmTempSilenced = true;
        }
    }

    public void ResetAlarms()
    {
        hasPlayedCaution = false;
        hasStartedLoop = false;
        alarmSilenced = false;
        oxygenAlarmUrgent.Stop();
    }

    public void ResetTempAlarms()
    {
        hasPlayedTempCaution = false;
        hasStartedTempLoop = false;
        alarmTempSilenced = false;
        tempAlarmUrgent.Stop();
    }
    private void ranndomEvent()
    {
        int eventhit = 2;
        int randomNumber = Random.Range(1, 3);
        randomEventTimer += Time.deltaTime;
        if (randomEventTimer > randomEventInterval)
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
        else if (!fuelbutton && fuelAmount > 0 && powerON.isActiveAndEnabled)
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
            if (powerAmount < -10)
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

    private void gameOver()
    {
        if (oxygenAmount <= 0) 
        {
            //disable all alarms
            gamePlaying = false;
            // show ui for gameover screen and switch off mainscreen ui
        }
        if (currentTemperature <= 0)
        {
            //disable all alarms
            gamePlaying = false;
            // show ui for gameover screen and switch off mainscreen ui
        }
    }



    private void Debugging()
    {

       //Debug.Log(fuelbutton);
    }
    
}

