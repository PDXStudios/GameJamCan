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
    [SerializeField] public float fuelAmount = 100.00f;
    [SerializeField] float fuelGain = 1.0f;
    [SerializeField] float fuelLoss = 1.0f;


    float maxPower = 100.0f;
    float maxOxygen = 100.0f;

    bool fuelbutton = false;


    private void Update()
    {
        powerManager();
        OxygenManager();
        FuelManager();
        //Debugging();

    }

    private void FuelManager()
    {
        // pressing fuel button on ui
        if (fuelbutton)
        {
            fuelAmount += fuelGain * Time.deltaTime;
        }
        else if (!fuelbutton && fuelAmount > 0 && powerON.isActiveAndEnabled)
        {
            fuelAmount -= fuelLoss * Time.deltaTime;
        }

    }
    private void powerManager()
    {
        
        if (powerON.isActiveAndEnabled && powerAmount < maxPower && fuelAmount > 0)
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
    public float GetFuelLevel()
    {
        return fuelAmount;
    }
    /*
    private void Debugging()
    {

        Debug.Log("Power Level: " + powerAmount);
        
        Debug.Log("Oxygen Levels: " + oxygenAmount);
    }
    */
}

