using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaterialChange : MonoBehaviour
{
    public Material turretOffMaterial;
    public Material turretOnMaterial;
    public Material turretDamagedMaterial;
    public GameObject PanelButton;
    public GameObject Turret;
    public Material turretDefaultMaterial;

    TurretHandling th;
    // Start is called before the first frame update
    void Start()
    {
        th = GetComponent<TurretHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (th.bIsTurretDamaged)
        {
            PanelButton.GetComponent<Renderer>().material = turretDamagedMaterial;
            Turret.GetComponent<Renderer>().material = turretDefaultMaterial;

        }
        else
        {
            if (th.bIsturretOn)
            {
                PanelButton.GetComponent<Renderer>().material = turretOnMaterial;
                Turret.GetComponent<Renderer>().material = turretOnMaterial;

            }
            else
            {
                PanelButton.GetComponent<Renderer>().material = turretOffMaterial;
                Turret.GetComponent<Renderer>().material = turretDefaultMaterial;

            }
        }
        
    }
}
