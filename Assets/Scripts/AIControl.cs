using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class AIControl : MonoBehaviour
{
    [SerializeField] float suspicionTime = 3f;
    [SerializeField] PatrolPath patrolPath;
    [SerializeField] float waypointDwellTime = 4f;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float patrolSpeedFraction = 0.2f;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float damage = 10f;
    [SerializeField] float attackSpeed = 1f;
    [Range(0, 1)]
    [SerializeField] float attackRange = 3f;
    NavMeshAgent agent;
    Health playerHP;
    GameObject player;
    Vector3 guardPosition;
    float timeSinceLastSawPlayer = Mathf.Infinity;
    float timeSinceArrivedAtWaypoint = Mathf.Infinity;
    int currentWaypointIndex = 0;
    float attackTimer = Mathf.Infinity;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHP = player.GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        guardPosition = transform.position;
    }
    private void Update()
    {
        UpdateTimers();
        PatrolBehaviour();
        PlayerInChaseRange();
        ChaseBehavior();
        AttackBehavior();
    }
    private void UpdateTimers()
    {
        attackTimer += Time.deltaTime;
        // timeSinceLastSawPlayer += Time.deltaTime;
        timeSinceArrivedAtWaypoint += Time.deltaTime;
    }

    private void PatrolBehaviour()
    {
        Vector3 nextPosition = guardPosition;

        if (patrolPath != null)
        {
            if (AtWaypoint())
            {
                timeSinceArrivedAtWaypoint = 0;
                CycleWaypoint();
            }
            nextPosition = GetCurrentWaypoint();
        }

        if (timeSinceArrivedAtWaypoint > waypointDwellTime)
        {
            agent.SetDestination(nextPosition);
            //  mover.StartMoveAction(nextPosition, patrolSpeedFraction);
        }
    }

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
    }

    void AttackBehavior()
    {
        if (PlayerInAttackRange() && attackTimer >= attackSpeed)
        {
            playerHP.TakeDamage(damage);
            attackTimer = 0;
        }
    }

        // private void UpdateAnimator()
        // {
        //     Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        //     Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        //     float speed = localVelocity.z;
        //     GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        // }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}