using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{

    public List<EnemySpawner> enemySpawners;
    float timer = 2F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            int randomIndex = Random.Range(0, 4);

            enemySpawners[randomIndex].SpawnEnemy();
            timer = 2F;
        }
    }
}
