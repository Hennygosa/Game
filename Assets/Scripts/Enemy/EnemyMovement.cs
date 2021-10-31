using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;
    private Vector3 movement;
    public float speed = 5f;
    private bool inCombat = false;

    private Vector3 direction;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(player.position, transform.position);
        direction = player.position - transform.position;
        if (distance < 30f)
            inCombat = true;
        if (distance <= 5f || !inCombat)
            Stop();
        if (inCombat)
            Move();
    }
    private void Move()
    {
        inCombat = true;
        
        rb.velocity = direction * speed;
        var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
    }
}
