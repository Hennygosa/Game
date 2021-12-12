using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
<<<<<<< HEAD
    Rigidbody rb;
=======
>>>>>>> dev
    public Transform attackPoint;
    public GameObject player;
    public GameObject projectile;

    public int attackDamage = 40;
    public float bulletSpeed = 30f;

<<<<<<< HEAD
    // Start is called before the first frame update
=======
>>>>>>> dev
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

<<<<<<< HEAD
    

    // Update is called once per frame
=======
>>>>>>> dev
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Shoot()
    {
<<<<<<< HEAD
        //play an attack animation

        //spawn the projectile
=======
        //анимация стрельбы

        //создать снаряд
>>>>>>> dev
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

<<<<<<< HEAD
    public void Hit()
    {
=======
    //ближний удар
    public void MeleeHit()
    {
        //анимация удара

        //нанесение урона игроку
>>>>>>> dev
        player.GetComponent<Player>().TakeDamage(attackDamage);
    }

}
