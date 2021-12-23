using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    public string enemyType;

    private Rigidbody rb;
    private Transform player;
    private Animator animator;

    ////�������
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

    //���������
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //��������� ���� � ������� ��������� � �����
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //���� �� � ������� ��������� � �� � ������� ����� - �����������
        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        //���� � ������� ��������� � �� � ������� ����� ��� ���� � ��� - ����������
        if (playerInSightRange && !playerInAttackRange || rb.GetComponent<Enemy>().inCombat)
        {
            rb.GetComponent<Enemy>().inCombat = true;
            ChasePlayer();
        }
        //���� � ������� ����� - �������
        if (playerInAttackRange)
        {
            transform.LookAt(player);
            GetComponent<EnemyCombat>().AttackPlayer();
        }
    }

    //private void Patroling()
    //{
    //    //���� ��� ����� - ����������
    //    if (!walkPointSet) SearchWalkPoint();
    //    //���� ���� ����� - ��� � ���
    //    if (walkPointSet)
    //        agent.SetDestination(walkPoint);
    //    //���� �������� ����� - ����� ���
    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;
    //    if (distanceToWalkPoint.magnitude < 1f)
    //        walkPointSet = false;
    //}
    //
    //private void SearchWalkPoint()
    //{
    //    //������������� �����
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);
    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    //    //���� �� ����� �� ��
    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //        walkPointSet = true;
    //}

    private void ChasePlayer()
    {
        animator.SetBool("Chasing", true);
        agent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
