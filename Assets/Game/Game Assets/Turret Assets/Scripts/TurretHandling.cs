using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretHandling : MonoBehaviour
{
    public bool bIsturretOn = false;
    public Transform CharacterShootingTransform;
    public GameObject energy;
    public CharacterActions character;
    EnergyHandling energyHandling;
    public bool bIsTurretDamaged = false;
    public bool bTurretIsRepairing = false;
    float repairTimer = 0F;
    public bool bIsCharacterNear = false;

    public AudioSource src;
    public AudioClip clip;

    public ManageTurretIcons DamagedIcon;

    // Start is called before the first frame update
    void Start()
    {
        energyHandling = energy.GetComponent<EnergyHandling>();
        src.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsturretOn)
        {
            energyHandling.DecreaseEnergy();
        }

        if (bTurretIsRepairing)
        {
            repairTimer += Time.deltaTime;
            DamagedIcon.SetSliderValue(repairTimer);
            if (repairTimer >= 2F)
            {
                RepairTurret();
            }
        }
    }

    public void ChangeTurretState()
    {
        if (bIsTurretDamaged)
        {
            StartRepairTurret();
        }
        else
        {
            bIsturretOn = !bIsturretOn;
        }
    }

    public void DamageTurret()
    {

        // If Character is near when Turret get either damaged or destroyed, character will die
        if (bIsCharacterNear)
        {
            character.Die();
        }

        if (!bIsTurretDamaged)
        {
            bIsTurretDamaged = true;
            DamagedIcon.SetIconVisible();
        }
        else
        {
            Destroy(gameObject);
            character.Die();
        }

        src.Play();

    }

    public void StartRepairTurret()
    {
        bTurretIsRepairing = true;
        DamagedIcon.SetSliderVisible();
    }

    public void RepairTurret()
    {
        bTurretIsRepairing = false;
        repairTimer = 0F;
        bIsTurretDamaged = false;
        DamagedIcon.SetIconInvisible();
        DamagedIcon.SetSliderInvisible();

    }
}
