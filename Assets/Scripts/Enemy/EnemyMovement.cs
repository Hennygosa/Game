using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
<<<<<<< HEAD
    private Rigidbody rb;
    public NavMeshAgent agent;
    public float speed = 5f;
    private bool inCombat = false;

    private Vector3 direction;
    private float distance;
    // Start is called before the first frame update
=======
    public NavMeshAgent agent;

    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 direction;
    private float distance;
    private bool inCombat = false;
    
>>>>>>> dev
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

<<<<<<< HEAD
    // Update is called once per frame
    void FixedUpdate()
    {
        
        distance = Vector3.Distance(player.position, transform.position);
        direction = (player.position - transform.position).normalized;
        if (distance < 30f)
            inCombat = true;
        if (!inCombat)
            Stop();
=======
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
>>>>>>> dev
        else
        {
            LookAt();
            Move();
<<<<<<< HEAD
=======
            //если расстояние <=5 - стоять
>>>>>>> dev
            if(distance <= 5f)
            rb.velocity = Vector3.zero;
        }
    }
    private void Move()
    {
        agent.SetDestination(player.position);
<<<<<<< HEAD
        //rb.velocity = direction * speed;
=======
>>>>>>> dev
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
