using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class AIPeople : AIController
{
    private Animator anim;
    public Transform currentTarget;
    public float changeTargetSpeed = 0.4f;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.radius = 0.001f;
        wayPoint = GameObject.Find("PeopleWayPoints").GetComponentsInChildren<Transform>().ToList();
        wayPoint.RemoveAt(0);
        anim = GetComponent<Animator>();
        FindTarget();
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        currentTarget = target;
    }

    protected override void MoveToTarget()
    {

        base.MoveToTarget();
        if(agent.velocity.magnitude < changeTargetSpeed)
        {
            FindTarget();
        }
        anim.SetFloat("Speed",agent.velocity.magnitude);
    }
}
