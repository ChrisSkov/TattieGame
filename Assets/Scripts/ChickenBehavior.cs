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
    [SerializeField] Transform[] moveDirections = new Transform[4];
    [Header("Variables")]
    [SerializeField] float yOffset = 1f;
    [SerializeField] float timeBetweenSmokeAndLeg = 1f;
    [SerializeField] float directionChangeTime;
    [SerializeField] float directionChangeTimeMax = 1f;
    [SerializeField] float directionChangeTimeMin = 5f;
    NavMeshAgent agent;
    Animator anim;
    Health health;
    // Start is called before the first frame update
    bool legHasSpawned = false;
    bool smokeHasSpawned = false;
    float timer = Mathf.Infinity;
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
        //  ChickenAnim();
        ChangeDirection();
        UpdateAnimator();
        timer += Time.deltaTime;

    }


    private void ChangeDirection()
    {
        if (timer > directionChangeTime)
        {
            int destination = Random.Range(0, 3);
            agent.SetDestination(moveDirections[destination].transform.position);
            transform.LookAt(agent.destination);
            timer = 0;
            directionChangeTime = Random.Range(directionChangeTimeMin, directionChangeTimeMax);
        }
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        anim.SetFloat("forwardSpeed", Mathf.Abs(speed));
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
