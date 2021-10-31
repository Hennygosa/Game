using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform target;
    Rigidbody rb;
    public float distance = 15f;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Rigidbody>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Distance(rb.position, target.position) <= distance)
            agent.SetDestination(target.transform.position);
        else
            return;
    }
}
