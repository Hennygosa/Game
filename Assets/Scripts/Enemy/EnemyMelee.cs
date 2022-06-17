using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public override void Attack()
    {
        if (!alreadyAttacked)
        {
            //play sound
            audioSource.PlayOneShot(attackSound);
            //play animation
            animator.Play("Attack01");
            //inflict damage
            player.GetComponent<Player>().TakeDamage(attackDamage);
            animator.SetBool("Chasing", false);
            //wait attack reset
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
}
