using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
public class AIControl : MonoBehaviour
{
    [SerializeField] float suspicionTime = 3f;
    [SerializeField] PatrolPath patrolPath;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float waypointDwellTime = 4f;
    [Range(0, 1)]
    [SerializeField] float patrolSpeedFraction = 0.2f;
    NavMeshAgent agent;


    //  Health health;

    //  GameObject player;


    Vector3 guardPosition;
    float timeSinceLastSawPlayer = Mathf.Infinity;
    float timeSinceArrivedAtWaypoint = Mathf.Infinity;
    int currentWaypointIndex = 0;

    private void Start()
    {
        //  health = GetComponent<Health>();

        // player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        guardPosition = transform.position;
    }
    private void Update()
    {
        UpdateTimers();
        PatrolBehaviour();
    }
    private void UpdateTimers()
    {
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
}