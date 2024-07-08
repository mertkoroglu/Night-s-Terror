using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    GameObject turretObj;
    TurretHandling turretHandling;
    EnemyAnim anim;
    int life = 4;
    bool bCanMove = true;
    float attackTimer = .5F;
    public GameObject energyItem;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<EnemyAnim>();

        if(turretObj != null)
            turretHandling = turretObj.GetComponent<TurretHandling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanMove)
        {
            rb.MovePosition(transform.position + transform.right.normalized * 8F * Time.deltaTime);
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
                anim.SetIsMoving(true);
            }
        }
    }

    public void TakeDamage()
    {
        life--;
        if (life == 0)
        {
            int rand = Random.Range(1, 11);
            Debug.Log(rand);
            if (rand == 10 || rand == 9)
            {
                Instantiate(energyItem, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2F, gameObject.transform.position.z), gameObject.transform.rotation);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(turretObj != null)
            if (other.gameObject.tag == "EnemyStop")
            {
                bCanMove = false;
                anim.SetIsMoving(false);
            }
    }

    public void SetTargetTurret(GameObject target)
    {
        turretObj = target;
    }
}
