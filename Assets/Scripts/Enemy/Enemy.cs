using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
<<<<<<< HEAD
    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthbar;
=======
    public Healthbar healthbar;
    public bool inCombat = false;
    public int maxHealth = 100;
    public int currentHealth;

>>>>>>> dev

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
<<<<<<< HEAD
        
=======
        //���� �� ������ 100% - � ���
        if (currentHealth < maxHealth)
            inCombat = true;
>>>>>>> dev
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
<<<<<<< HEAD
        //play hurt animation
=======
        //�������� ��������� �����
>>>>>>> dev

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
<<<<<<< HEAD
        Destroy(gameObject);
        Debug.Log("Enemy died!");

        //die animation

        //disable the enemy
=======
        //�������� ������
        Destroy(gameObject);
>>>>>>> dev
    }
}
