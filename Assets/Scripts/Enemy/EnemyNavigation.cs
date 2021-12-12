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

    //патруль
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //атака
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //состояния
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
        //проверяем если в радиусе видимости и атаки
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        //если не в радиусе видимости и не в радиусе атаки - патрулируем
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        //если в радиусе видимости и не в радиусе атаки или враг в бою - преследуем
        if (playerInSightRange && !playerInAttackRange || rb.GetComponent<Enemy>().inCombat)
        {
            rb.GetComponent<Enemy>().inCombat = true;
            ChasePlayer();
        }
        //если в радиусе видимости и атаки - атакуем
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        //если стоим - стоим =)
        if (rb.velocity == Vector3.zero)
            rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void Patroling()
    {
        //если нет точек - генерируем
        if (!walkPointSet) SearchWalkPoint();
        //если есть точка - идём к ней
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        //если достигли точки - точек нет
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //сгенерировать точку
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //если на земле то ок
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
            //если враг дальнего боя - стреляем
            if (gameObject.tag == "EnemyRanged")
                GetComponent<EnemyCombat>().Shoot();
            //если ближнего - бьем
            if (gameObject.tag == "EnemyMelee")
                GetComponent<EnemyCombat>().MeleeHit();
            //атаковали - ждём кд
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
