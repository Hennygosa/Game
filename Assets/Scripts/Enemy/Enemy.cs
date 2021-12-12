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
        //если хп меньше 100% - в бою
        if (currentHealth < maxHealth)
            inCombat = true;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        //анимация получения урона

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //анимация смерти
        Destroy(gameObject);
    }
}
