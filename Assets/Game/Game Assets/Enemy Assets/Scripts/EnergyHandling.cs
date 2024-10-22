using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandling : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentEnergy = 100F;
    public float Timer = 0F;
    public bool bEnergyOut = false;
    public List<TurretHandling> turrets;

    public AudioSource src;
    public AudioClip clip;

    void Start()
    {
        src.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (bEnergyOut == true)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0F)
            {
                bEnergyOut = false;
                currentEnergy = 100F;
            }
            //Debug.Log("energy Out Timer: " + Timer);
        }
        else
        {
            //Debug.Log("Current energy: " +  currentEnergy);
        }

        if (turrets[0].bIsturretOn == false && turrets[1].bIsturretOn == false && turrets[2].bIsturretOn == false && turrets[3].bIsturretOn == false && currentEnergy < 100F)
        {
            currentEnergy += 10 * Time.deltaTime;
            //Debug.Log("Current energy: " + currentEnergy);
        }





    }

    public void AddEnergy()
    {
        if(currentEnergy + 10 > 100)
        {
            currentEnergy = 100;
        }
        else
        {
            currentEnergy += 10;
        }

    }

    public void PlaySound()
    {
        src.Play();
    }


    public void DecreaseEnergy()
    {
        if(currentEnergy > 0) {
            currentEnergy -= 2 * Time.deltaTime;
        }
        else
        {
            if(bEnergyOut == false)
                StartEnergyGeneratorTimer();
        }

    }

    void StartEnergyGeneratorTimer()
    {
        bEnergyOut = true;
        if (Timer <= 0)
        {
            Timer = 5F;
        }
    }


}
