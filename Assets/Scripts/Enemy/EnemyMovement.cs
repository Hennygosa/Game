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
        //������� ���������� � �����������   
        distance = Vector3.Distance(player.position, transform.position);
        direction = (player.position - transform.position).normalized;
        //���� ���������� < 30 - � ���
        if (distance < 30f)
            inCombat = true;
        //���� �� � ��� - ������
        if (!inCombat)
            Stop();
        //����� - �������� �� ������, ���������
        else
        {
            LookAt();
            Move();
            //���� ���������� <=5 - ������
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
