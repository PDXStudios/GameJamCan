using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLevels : MonoBehaviour
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
        float oxygenLevels = gameController.GetOxygenLevel();

        for(int i = 0; i <healthBars.Length; i++)
        {
            int threshold = 100 - (i + 1) * 10;
            healthBars[i].gameObject.SetActive(oxygenLevels >= threshold);
        }
    }
}
