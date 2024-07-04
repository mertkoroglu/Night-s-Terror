using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    GameObject turretObj;
    TurretHandling turretHandling;
    int life = 4;
    bool bCanMove = true;
    float attackTimer = 1.5F;

    // Start is called before the first frame update
    void Start()
    {
        if(turretObj != null)
            turretHandling = turretObj.GetComponent<TurretHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanMove)
        {
            rb.MovePosition(transform.position + transform.right.normalized * 30F * Time.deltaTime);
        }
        else
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                turretHandling.DamageTurret();
                //Change this later
                Destroy(gameObject);
                bCanMove = true;
            }
        }
    }


    public void TakeDamage()
    {
        life--;
        if(life == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(turretObj != null)
            if (other.gameObject.tag == "EnemyStop")
            {
                bCanMove = false;
            }
    }

    public void SetTargetTurret(GameObject target)
    {
        turretObj = target;
    }
}
