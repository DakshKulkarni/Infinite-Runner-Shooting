using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public Vector3 nextSpawnPoint;
    public GameObject enemyPrefab;
   public void Spawner(bool spawnItem)
    {
       GameObject temp= Instantiate(groundTile,nextSpawnPoint,Quaternion.identity);
        nextSpawnPoint=temp.transform.GetChild(1).transform.position;
        if(spawnItem)
        {
            temp.GetComponent<GroundTile>().coinSpawner();
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnEnemies();
        }
    }
    void Start()
    {   
        for(int i=0;i<10;i++)
        {
            if(i<4)
            {
                Spawner(false);
            }
            else{
                Spawner(true);
            }
        }
    }
}
