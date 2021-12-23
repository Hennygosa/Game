using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public AudioClip getHitSound;
    public Healthbar healthbar;

    private int currentHealth;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        //audioSource.PlayOneShot(getHitSound, 0.2f);
        //�������� ��������� �����

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
        //�������� ������
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
