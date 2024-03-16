using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject[] obstacleprefab;
    public GameObject coinPrefab;
    public GameObject enemyPrefab;
    public int maxCoinNumber = 7;
    public int maxEnemyNumber = 1;
    private int currentEnemyCount = 0;
    public float enemySpawnProbability=0.5f;

    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.Spawner(true);
        Destroy(gameObject, 3);
    }
    private void Update()
    {

    }
    public void SpawnObstacle()
    {
        if (obstacleprefab.Length == 0)
        {
            Debug.Log("No obstacle assigned");
        }
        int obstacleIndex = Random.Range(0, obstacleprefab.Length);
        GameObject obstaclePrefab = obstacleprefab[obstacleIndex];
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.Euler(0f, 90f, 0f), transform);
    }
    public void coinSpawner()
    {
        int coinNumber = Random.Range(1, maxCoinNumber + 1);
        for (int i = 0; i < coinNumber; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = RandomPointCollider(GetComponent<Collider>());
        }
    }
public void SpawnEnemies()
{
    if (currentEnemyCount > 0 || Random.value > 0.5f)
    {
        return;
    }
    float randomFactor = Random.Range(0f, 1f);
    float spawnProbability = Mathf.Clamp01(enemySpawnProbability * randomFactor);

    if (Random.value > spawnProbability)
    {
        return;
    }

    Vector3 spawnPosition = new Vector3(
        Random.Range(transform.position.x - 7f, transform.position.x + 7f),
        transform.position.y,
        Random.Range(transform.position.z - 7f, transform.position.z + 7f)
    );
    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 180f, 0f),transform);
    EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
    if (enemyMovement != null)
    {
        enemyMovement.SetMovementBounds(transform.position.x - 7f, transform.position.x + 7f);
    }

    currentEnemyCount++;
}
    Vector3 RandomPointCollider(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                                     Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                                     Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = RandomPointCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
