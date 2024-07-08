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

    public AudioSource src;
    public AudioClip fireSound;

    // Start is called before the first frame update
    void Start()
    {
        th = gameObject.GetComponent<TurretHandling>();
        energyHandling = energy.GetComponent<EnergyHandling>();

        src.clip = fireSound;
        src.volume = .5F;
    }

    // Update is called once per frame
    void Update()
    {
        if (!energyHandling.bEnergyOut && !th.bIsTurretDamaged)
        {
            if (th.bIsturretOn)
            {
                Timer -= Time.deltaTime;

                if (Timer <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    Timer = DefTime;
                    src.pitch = Random.Range(.5F, 1F);

                    src.Play();
                }

            }
            else
            {
                Timer = DefTime;
            }
        }
    }
}
