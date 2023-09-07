using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarLevels : MonoBehaviour
{

    [SerializeField] Image[] healthBars;
    [SerializeField] GameController gameController;

    
    private void Start()
    {

    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float powerLevels = gameController.GetPowerLevel();

        for(int i = 0; i < healthBars.Length; i++)
        {
            int threshold = 100 - (i + 1) * 10;
            healthBars[i].gameObject.SetActive(powerLevels >= threshold);
        }
    }
}
