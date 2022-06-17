using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().attackDamage;
    }
    
    protected override void OnTriggerEnter(Collider collider)
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
}
