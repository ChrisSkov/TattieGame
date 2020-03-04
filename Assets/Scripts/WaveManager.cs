using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float spawnTime;
    [SerializeField] float radius = .5f;
    [SerializeField] float timer = Mathf.Infinity;
    [SerializeField] bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        SpawnEnemy();

        RandomSpawnPlacement();
    }

    int RandomSpawnPlacement()
    {
        int i;
        return i = Random.Range(0, spawnPoints.Length);
    }

    void SpawnEnemy()
    {
        timer += Time.deltaTime;
        //  spawning = true;
        foreach (var enemy in enemies)
        {
            GameObject spawnPoint = spawnPoints[RandomSpawnPlacement()];
            if (timer >= spawnTime)
            {
                var clone = Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
                timer = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach(var s in spawnPoints)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(s.transform.position, radius);
        }
    }
}
