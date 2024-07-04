using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnBullet : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePoint;
    public GameObject energy;

    float DefTime = .5F;
    float Timer = .5F;

    TurretHandling th;
    EnergyHandling energyHandling;


    // Start is called before the first frame update
    void Start()
    {
        th = gameObject.GetComponent<TurretHandling>();
        energyHandling = energy.GetComponent<EnergyHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!energyHandling.bEnergyOut)
        {
            if (th.bIsturretOn)
            {
                Timer -= Time.deltaTime;

                if (Timer <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    Timer = DefTime;
                }

            }
            else
            {
                Timer = DefTime;
            }
        }
    }
}
