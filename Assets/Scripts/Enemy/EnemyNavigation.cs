using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    Rigidbody rb;
<<<<<<< HEAD
    public NavMeshAgent agent;
    Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public string enemyType;

    //Patroling
=======
    Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    public string enemyType;

    //�������
>>>>>>> dev
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

<<<<<<< HEAD
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
=======
    //�����
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //���������
>>>>>>> dev
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
<<<<<<< HEAD
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //ChasePlayer();

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange || rb.GetComponent<Enemy>().currentHealth < rb.GetComponent<Enemy>().maxHealth) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

=======
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
>>>>>>> dev
        if (rb.velocity == Vector3.zero)
            rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void Patroling()
    {
<<<<<<< HEAD
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
=======
        //���� ��� ����� - ����������
        if (!walkPointSet) SearchWalkPoint();
        //���� ���� ����� - ��� � ���
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        //���� �������� ����� - ����� ���
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
>>>>>>> dev
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
<<<<<<< HEAD
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

=======
        //������������� �����
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //���� �� ����� �� ��
>>>>>>> dev
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
<<<<<<< HEAD
        //make sure enemy doesnt move
        //agent.SetDestination(transform.position);

=======
>>>>>>> dev
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
<<<<<<< HEAD
            if (gameObject.tag == "EnemyRanged")
                GetComponent<EnemyCombat>().Shoot();
            if (gameObject.tag == "EnemyMelee")
                GetComponent<EnemyCombat>().Hit();

=======
            //���� ���� �������� ��� - ��������
            if (gameObject.tag == "EnemyRanged")
                GetComponent<EnemyCombat>().Shoot();
            //���� �������� - ����
            if (gameObject.tag == "EnemyMelee")
                GetComponent<EnemyCombat>().MeleeHit();
            //��������� - ��� ��
>>>>>>> dev
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
