using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected int damage;
    protected virtual void Start()
    {
        damage = 0;
    }
    protected void Update()
    {
        //destroy every 15 sec
        InvokeRepeating("DeleteBullets", 15, 15);
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        //inflict damage to player
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //pass through other enemies
        else if (collider.gameObject.CompareTag("Enemy"))
            return;
        //destroy if hits wall
        else
            Destroy(gameObject);
    }

    private void DeleteBullets()
    {
        Destroy(gameObject);
    }
}
