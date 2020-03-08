using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Enemies and spawn locations")]
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] spawnPoints;
    [Header("Tuning")]
    [Tooltip("How fast do enemies spawn?")]
    [SerializeField] float spawnTime = 5f;
    [Tooltip("When does the next enemy spawn?")]
    [SerializeField] float timer = Mathf.Infinity;
    [Header("For debugging")]
    [Tooltip("Radius of gizmo")]
    [SerializeField] float radius = .5f;
    [Tooltip("Are we currently spawning enemies?")]
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
