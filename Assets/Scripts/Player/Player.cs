using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip getHitSound;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    private Healthbar healthbar;

    void Start()
    {
        healthbar = GameObject.Find("PlayerHealthBar").GetComponent<Healthbar>();
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        //get hit sound
        //get hit animation

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        //death sound
        //death animation
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //heal on healing pick-up
        if (other.gameObject.CompareTag("Heal") && currentHealth < maxHealth)
        {
            currentHealth += other.gameObject.GetComponent<Heal>().healingAmount;
            healthbar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
    }
}
