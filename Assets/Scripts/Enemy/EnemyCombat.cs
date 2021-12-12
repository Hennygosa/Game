using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Rigidbody rb;
    public Transform attackPoint;
    public GameObject player;
    public GameObject projectile;

    public int attackDamage = 40;
    public float bulletSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Shoot()
    {
        //play an attack animation

        //spawn the projectile
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    public void Hit()
    {
        player.GetComponent<Player>().TakeDamage(attackDamage);
    }

}
