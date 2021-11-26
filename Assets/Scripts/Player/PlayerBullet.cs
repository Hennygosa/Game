using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    private int damage;
    void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatRanged>().attackDamage;
    }

    void Update()
    {
        //�� ������ ������ ������� ���� ������ 15
        InvokeRepeating("DeleteBullets", 15, 15);
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        //���� ����� �� ����� - ������� ���� � ������� ����
        if (collider.gameObject.CompareTag("EnemyRanged") || collider.gameObject.CompareTag("EnemyMelee"))
        {
            target = collider.gameObject.GetComponent<Transform>();
            target.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //���� ����� � ������ ������ - ��������� ����
        else if (collider.gameObject.tag == "Projectile")
            return;
        //� ��������� ������� ������� ����
        else
            Destroy(gameObject);
    }

    private void DeleteBullets()
    {
        Destroy(gameObject);
    }
}
