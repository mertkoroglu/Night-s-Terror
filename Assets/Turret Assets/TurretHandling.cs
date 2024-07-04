using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandling : MonoBehaviour
{
    public bool bIsturretOn = false;
    public Transform CharacterShootingTransform;
    public GameObject energy;
    EnergyHandling energyHandling;
    public bool bIsTurretDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        energyHandling = energy.GetComponent<EnergyHandling>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsturretOn)
        {
            energyHandling.DecreaseEnergy();
        }
    }


    public void ChangeTurretState()
    {
        bIsturretOn = !bIsturretOn;
    }

    public void DamageTurret()
    {
        if (!bIsTurretDamaged)
        {
            bIsTurretDamaged = true;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void RepairTurret()
    {
        bIsTurretDamaged = false;
    }
}
