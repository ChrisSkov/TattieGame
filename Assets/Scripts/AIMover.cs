using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMover : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float chaseRange = 10f;

    Health playerHP;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHP = GameObject.FindWithTag("Player").GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToTarget(Health target)
    {
        agent.SetDestination(target.transform.position);
    }

    public bool PlayerInChaseRange()
    {
        return Vector3.Distance(transform.position, playerHP.transform.position) < chaseRange;
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
