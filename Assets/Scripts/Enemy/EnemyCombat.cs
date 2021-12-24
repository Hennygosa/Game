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
        //�������� ��������
        animator.Play("attack01");
        //������� ������
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, transform.localRotation).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    //������� ����
    public void MeleeHit()
    {
        audioSource.PlayOneShot(meleeAttackSound);
        //�������� �����
        animator.Play("Attack01");
        //��������� ����� ������
        player.GetComponent<Player>().TakeDamage(attackDamage);
    }

    public void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            //���� ���� �������� ��� - ��������
            if (gameObject.tag == "EnemyRanged")
            {
                Shoot();
            }
            //���� �������� - ����
            if (gameObject.tag == "EnemyMelee")
            {
                MeleeHit();
                animator.SetBool("Chasing", false);
            }
            //��������� - ��� ��
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
