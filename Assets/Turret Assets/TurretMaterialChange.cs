using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaterialChange : MonoBehaviour
{
    public Material turretOffMaterial;
    public Material turretOnMaterial;
    public Material turretDamagedMaterial;

    TurretHandling th;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        th = GetComponent<TurretHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (th.bIsTurretDamaged)
        {
            GetComponent<Renderer>().material = turretDamagedMaterial;
        }
        else
        {
            if (th.bIsturretOn)
            {
                GetComponent<Renderer>().material = turretOnMaterial;
            }
            else
            {
                GetComponent<Renderer>().material = turretOffMaterial;
            }
        }
        
    }
}
