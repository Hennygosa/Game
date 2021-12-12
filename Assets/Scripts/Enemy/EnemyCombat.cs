using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject player;
    public GameObject projectile;

    public int attackDamage = 40;
    public float bulletSpeed = 30f;

    void Start()
    {
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
        //�������� ��������

        //������� ������
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    //������� ����
    public void MeleeHit()
    {
        //�������� �����

        //��������� ����� ������
        player.GetComponent<Player>().TakeDamage(attackDamage);
    }

}
