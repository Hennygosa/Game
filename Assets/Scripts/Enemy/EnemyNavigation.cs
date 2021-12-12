using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    Rigidbody rb;
    Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    public string enemyType;

    //�������
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //�����
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //���������
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
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
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        //���� � ������� ��������� � �� � ������� ����� ��� ���� � ��� - ����������
        if (playerInSightRange && !playerInAttackRange || rb.GetComponent<Enemy>().inCombat)
        {
            rb.GetComponent<Enemy>().inCombat = true;
            ChasePlayer();
        }
        //���� � ������� ��������� � ����� - �������
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        //���� ����� - ����� =)
        if (rb.velocity == Vector3.zero)
            rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void Patroling()
    {
        //���� ��� ����� - ����������
        if (!walkPointSet) SearchWalkPoint();
        //���� ���� ����� - ��� � ���
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        //���� �������� ����� - ����� ���
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //������������� �����
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //���� �� ����� �� ��
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //���� ���� �������� ��� - ��������
            if (gameObject.tag == "EnemyRanged")
                GetComponent<EnemyCombat>().Shoot();
            //���� �������� - ����
            if (gameObject.tag == "EnemyMelee")
                GetComponent<EnemyCombat>().MeleeHit();
            //��������� - ��� ��
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
