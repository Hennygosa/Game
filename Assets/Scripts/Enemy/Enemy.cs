using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Healthbar healthbar;
    public bool inCombat = false;
    public int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //���� �� ������ 100% - � ���
        if (currentHealth < maxHealth)
            inCombat = true;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        //�������� ��������� �����

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //�������� ������
        Destroy(gameObject);
    }
}
