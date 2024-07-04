using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionCheck : MonoBehaviour
{
    public GameObject turret;
    TurretHandling th;

    // Start is called before the first frame update
    void Start()
    {
        th = turret.GetComponent<TurretHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            th.ChangeTurretState();
        }
    }
}
