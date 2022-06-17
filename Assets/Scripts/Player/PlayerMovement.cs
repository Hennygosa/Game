using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;


    public float speed = 10f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }
    void Move()
    {
        Vector3 movement = Vector3.zero ;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (movement == Vector3.zero)
            rb.velocity = Vector3.zero;
        rb.velocity = movement * speed * Time.deltaTime;
        //animator variables
        animator.SetFloat("Speed", rb.velocity.magnitude);
        animator.SetFloat("AnimationSpeed", rb.velocity.magnitude * 0.1f);
    }

    void Turn()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}
