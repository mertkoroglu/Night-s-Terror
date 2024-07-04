using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    float bulletLife = 0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletLife += Time.deltaTime;


        if(bulletLife >= 3F)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            GameObject enemyGameObject = collision.collider.gameObject;
            Enemy enemy = enemyGameObject.GetComponent<Enemy>();

            enemy.TakeDamage();
            Destroy(gameObject);
        }
    }

}
