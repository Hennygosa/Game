using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 direction;
    private float distance;
    private bool inCombat = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        //считаем расстояние и направление   
        distance = Vector3.Distance(player.position, transform.position);
        direction = (player.position - transform.position).normalized;
        //если расстояние < 30 - в бою
        if (distance < 30f)
            inCombat = true;
        //если не в бою - стоять
        if (!inCombat)
            Stop();
        //иначе - смотреть на игрока, двигаться
        else
        {
            LookAt();
            Move();
            //если расстояние <=5 - стоять
            if(distance <= 5f)
            rb.velocity = Vector3.zero;
        }
    }
    private void Move()
    {
        agent.SetDestination(player.position);
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
    }

    private void LookAt()
    {
        var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}
