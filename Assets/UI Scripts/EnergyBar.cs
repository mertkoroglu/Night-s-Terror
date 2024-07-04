using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider sl;
    public GameObject energyObj;
    EnergyHandling eh;
    // Start is called before the first frame update
    void Start()
    {
        eh = energyObj.GetComponent<EnergyHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        sl.value = eh.currentEnergy;

        if (eh.bEnergyOut == true)
        {
            sl.transform.localScale = new Vector3(0, 0, 0);
        }
        else if(eh.bEnergyOut == false) 
        {
            sl.transform.localScale = new Vector3(1, 1, 1);

        }

    }
}
