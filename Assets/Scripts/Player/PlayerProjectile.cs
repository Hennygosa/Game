using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackRanged>().attackDamage;
    }

    protected override void OnTriggerEnter(Collider collider)
    {
        //on enemy hit
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //pass through other projectiles
        else if (collider.gameObject.CompareTag("Projectile"))
            return;
        else
            Destroy(gameObject);
    }
}
