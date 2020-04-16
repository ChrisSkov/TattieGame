using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class AIControl : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] float damage = 10f;
    [Range(0, 1)]
    [SerializeField] float attackSpeed = 1f;
    [SerializeField] float attackRange = 3f;
    [SerializeField] float chaseRange = 10f;
    [Header("Patrolling")]
    [SerializeField] PatrolPath patrolPath;
    [Tooltip("How fast do we patrol compared to normal speed")]
    [SerializeField] float waypointDwellTime = 4f;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float despawnTime = 3f;
    NavMeshAgent agent;
    Health playerHP;
    GameObject player;
    Vector3 guardPosition;
    float timeSinceArrivedAtWaypoint = Mathf.Infinity;
    int currentWaypointIndex = 0;
    float attackTimer = Mathf.Infinity;
    Animator anim;
    Health health;
    private void Start()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHP = player.GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        guardPosition = transform.position;
    }
    private void Update()
    {
        // if (!health.IsDead())
        // {}


        if (health.IsDead())
        {
            agent.isStopped = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.detectCollisions = false;
            Destroy(gameObject, despawnTime);
            return;
        }
        UpdateTimers();
        //PatrolBehaviour();
        PlayerInChaseRange();
        ChaseBehavior();
        AttackBehavior();
        UpdateAnimator();


    }
    private void UpdateTimers()
    {
        attackTimer += Time.deltaTime;
        timeSinceArrivedAtWaypoint += Time.deltaTime;
    }

    // private void PatrolBehaviour()
    // {
    //     Vector3 nextPosition = guardPosition;

    //     if (patrolPath != null)
    //     {
    //         if (AtWaypoint())
    //         {
    //             timeSinceArrivedAtWaypoint = 0;
    //             CycleWaypoint();
    //         }
    //         nextPosition = GetCurrentWaypoint();
    //     }

    //     if (timeSinceArrivedAtWaypoint > waypointDwellTime)
    //     {
    //         agent.SetDestination(nextPosition);
    //     }
    // }

    private Vector3 GetCurrentWaypoint()
    {
        return patrolPath.GetWaypoint(currentWaypointIndex);
    }

    private void CycleWaypoint()
    {
        currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint < waypointTolerance;
    }

    bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) < chaseRange;
    }

    bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) < attackRange;

    }
    void ChaseBehavior()
    {
        if (PlayerInChaseRange())
        {
            agent.SetDestination(player.transform.position);
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            agent.destination = transform.position;
        }
    }

    void AttackBehavior()
    {
        if (PlayerInAttackRange() && attackTimer >= attackSpeed)
        {
            TriggerAttack();
            playerHP.TakeDamage(damage);
            attackTimer = 0;
        }
        else if (!PlayerInAttackRange())
        {
            StopAttack();
        }
    }
    private void StopAttack()
    {
        GetComponent<Animator>().ResetTrigger("attack");
        GetComponent<Animator>().SetTrigger("stopAttack");
    }
    private void TriggerAttack()
    {
        GetComponent<Animator>().ResetTrigger("stopAttack");
        GetComponent<Animator>().SetTrigger("attack");
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        anim.SetFloat("forwardSpeed", Mathf.Abs(speed));
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}