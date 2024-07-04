using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject assignedTurret;
    Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SpawnEnemy()
    {
        //enemy = enemyObj.GetComponent<Enemy>();

        GameObject spawnedEnemy = Instantiate(enemyObj, gameObject.transform.position, gameObject.transform.rotation);

        enemyScript = spawnedEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.SetTargetTurret(assignedTurret);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
