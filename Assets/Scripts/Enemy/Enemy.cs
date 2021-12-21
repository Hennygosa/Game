using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public DropItem heal;
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
        CheckDrop();
    }

    public void CheckDrop()
    {
        int rnd = (int)Random.Range(0, 100);

        if (heal.chance < rnd)
        {
            heal.CreateDropItem(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));
            return;
        }
    }
}
