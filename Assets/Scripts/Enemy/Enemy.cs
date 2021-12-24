using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public DropItem heal;
    public Healthbar healthbar;
    public Animator animator;
    public bool inCombat = false;
    public int maxHealth = 100;
    public int currentHealth;
    public AudioClip deathSound;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
            inCombat = true;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        animator.Play("GetHit");
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        audioSource.PlayOneShot(deathSound, 0.2f);
        animator.Play("Die");
        gameObject.GetComponent<EnemyNavigation>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2f);
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
