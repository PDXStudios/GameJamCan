using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelLevel : MonoBehaviour
{
    [SerializeField] Image[] healthBars;
    [SerializeField] GameController gameController;

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fuelLevel = gameController.GetFuelLevel();

        for (int i = 0; i < healthBars.Length; i++)
        {
            int threshold = 100 - (i + 1) * 10;
            healthBars[i].gameObject.SetActive(fuelLevel >= threshold);
        }
    }
}
