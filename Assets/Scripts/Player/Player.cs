using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public AudioClip getHitSound;
    
    private Healthbar healthbar;
    private int currentHealth;
    private AudioSource audioSource;

    void Start()
    {
        healthbar = GameObject.Find("PlayerHealthBar").GetComponent<Healthbar>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        //audioSource.PlayOneShot(getHitSound, 0.2f);
        //анимация получения урона

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        //анимация смерти
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
