using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    
    

    bool lights = false;
    float maxPower = 100.0f;
    float maxOxygen = 100.0f;

    


    private void Update()
    {
        powerManager();
        OxygenManager();
        //Debugging();

    }

    private void powerManager()
    {
        
        if (powerON.isActiveAndEnabled && powerAmount < maxPower)
        {
            powerAmount += batteryChargeRate * Time.deltaTime;
        }
        else
        {
            powerAmount -= batteryDischargeRate * Time.deltaTime;
            
        }
    }
    private void OxygenManager()
    {
        if (oxygenON.isActiveAndEnabled && powerAmount >= 0 && oxygenAmount < maxOxygen)
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
    /*
    private void Debugging()
    {

        Debug.Log("Power Level: " + powerAmount);
        
        Debug.Log("Oxygen Levels: " + oxygenAmount);
    }
    */
}

