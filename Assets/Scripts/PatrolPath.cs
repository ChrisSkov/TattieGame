using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    const float waypointGizmoRadius = 0.3f;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            int j = GetNextIndex(i);
            Gizmos.DrawSphere(GetWaypoint(i), waypointGizmoRadius);
            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));

        }
    }



    public int GetNextIndex(int i)
    {
        if (i + 1 == transform.childCount)
        {
            return 0;
        }
        return i + 1;
    }

    public Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }
    // [SerializeField] Transform patrolPath;
    // NavMeshAgent agent;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     agent = GetComponent<NavMeshAgent>();
    //     Vector3[] wayPoints = new Vector3[patrolPath.childCount];
    //     for (int i = 0; i < wayPoints.Length; i++)
    //     {
    //         wayPoints[i] = patrolPath.GetChild(i).position;
    //     }

    // }

    // private void OnDrawGizmos()
    // {
    //     Vector3 startPos = patrolPath.GetChild(0).position;
    //     Vector3 previousPos = startPos;

    //     foreach (Transform wayPoint in patrolPath)
    //     {
    //         Gizmos.DrawSphere(wayPoint.position, 3f);
    //         Gizmos.DrawLine(previousPos, wayPoint.position);
    //         previousPos = wayPoint.position;
    //     }
    //     Gizmos.DrawLine(previousPos, startPos);
    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
