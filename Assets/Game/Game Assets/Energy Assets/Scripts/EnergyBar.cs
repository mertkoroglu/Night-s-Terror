using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public GameObject energyObj;
    EnergyHandling eh;
    public HealthSystem healthSystem;
    public TextMeshProUGUI timerText;
    public GameObject energyComponents;
    public GameObject timerComponents;

    // Start is called before the first frame update
    void Start()
    {
        eh = energyObj.GetComponent<EnergyHandling>();
    }

    // Update is called once per frame
    void Update()
    {
       // sl.value = eh.currentEnergy;

        if (eh.bEnergyOut == true)
        {
            //healthSystem.transform.localScale = new Vector3(0, 0, 0);
            timerText.text = Math.Truncate(eh.Timer).ToString();
            energyComponents.transform.localScale = new Vector3(0, 0, 0);
            timerComponents.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(eh.bEnergyOut == false) 
        {
            //healthSystem.transform.localScale = new Vector3(1, 1, 1);
            timerComponents.transform.localScale = new Vector3(0, 0, 0);
            energyComponents.transform.localScale = new Vector3(1, 1, 1);
        }
        healthSystem.manaPoint = eh.currentEnergy;

    }
}
