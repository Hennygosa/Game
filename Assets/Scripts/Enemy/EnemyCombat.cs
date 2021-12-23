using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject player;
    public GameObject projectile;
    public Animator animator;
    public int attackDamage = 40;
    public float bulletSpeed = 30f;
    public float timeBetweenAttacks;
    public AudioClip meleeAttackSound;
    public AudioClip rangedAttackSound;
    

    private AudioSource audioSource;
    private bool alreadyAttacked = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(rangedAttackSound);
        //анимация стрельбы
        animator.Play("attack01");
        //создать снаряд
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, transform.localRotation).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    //ближний удар
    public void MeleeHit()
    {
        audioSource.PlayOneShot(meleeAttackSound);
        //анимация удара
        animator.Play("Attack01");
        //нанесение урона игроку
        player.GetComponent<Player>().TakeDamage(attackDamage);
    }

    public void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            //если враг дальнего боя - стреляем
            if (gameObject.tag == "EnemyRanged")
            {
                Shoot();
            }
            //если ближнего - бьем
            if (gameObject.tag == "EnemyMelee")
            {
                MeleeHit();
                animator.SetBool("Chasing", false);
            }
            //атаковали - ждём кд
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
