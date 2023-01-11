using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] protected List<Transform> wayPoint;
    protected Transform target;
    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void FindTarget()
    {
        target = wayPoint[Random.Range(0, wayPoint.Count)];
    }

    protected virtual void MoveToTarget()
    {
        agent.SetDestination(target.position);
        Vector3 distance = transform.position - target.position;
        if (distance.magnitude < 0.5f)
        {
            Transform prev = target;
            wayPoint.Remove(target);
            FindTarget();
            wayPoint.Add(prev);
        }
    }
}
