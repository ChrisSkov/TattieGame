using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenBehavior : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject chickenLeg;
    [SerializeField] GameObject chickenMesh;
    [Header("Variables")]
    [SerializeField] float yOffset = 1f;
    [SerializeField] float timeBetweenSmokeAndLeg = 1f;
    NavMeshAgent agent;
    Animator anim;
    Health health;
    // Start is called before the first frame update
    bool legHasSpawned = false;
    bool smokeHasSpawned = false;
    float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        NormalDeath();

    }

    void NormalDeath()
    {
        if (health.IsDead())
        {
            Destroy(gameObject);
        }
    }
    public void SpawnChickenLeg()
    {
        if (health.IsDead())
        {
            chickenMesh.SetActive(false);
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
            var particleClone = Instantiate(particle, spawnPos, particle.transform.rotation);
            var clone = Instantiate(chickenLeg, spawnPos, transform.rotation);
            legHasSpawned = true;
            Destroy(gameObject, 0.5f);

        }
    }
}
