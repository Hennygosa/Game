using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemy
{
    public GameObject attackPoint;
    public GameObject projectile;
    public float bulletSpeed = 30f;

    public override void Attack()
    {
        if (!alreadyAttacked)
        {
            //play sound
            audioSource.PlayOneShot(attackSound);
            //play animation
            animator.Play("Attack01");
            //spawn projectile
            Rigidbody bullet = Instantiate(projectile, attackPoint.transform.position, transform.localRotation).GetComponent<Rigidbody>();
            bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            animator.SetBool("Chasing", false);
            //wait attack reset
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
}
