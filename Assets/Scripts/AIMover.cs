using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMover : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float chaseRange = 10f;
    bool hasWarped = false;
    Health playerHP;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHP = GameObject.FindWithTag("Player").GetComponent<Health>();
        //agent.Warp(transform.position);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToTarget(Health target)
    {
        if (!hasWarped)
        {
            agent.Warp(agent.transform.position);
            hasWarped = true;
        }
        agent.SetDestination(target.transform.position);
    }

    public bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, playerHP.transform.position) <= chaseRange;
    }

    public void CancelMove()
    {
        agent.isStopped = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
