using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public bool inCombat = false;
    public int attackDamage = 40;
    
    [SerializeField] protected Healthbar healthbar;
    [SerializeField] protected DropItem heal;
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected AudioClip getHitSound;
    [SerializeField] protected AudioClip deathSound;
    [SerializeField] protected float timeBetweenAttacks;

    protected Animator animator;
    protected AudioSource audioSource;
    protected GameObject player;
    protected int currentHealth;
    protected bool alreadyAttacked = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (currentHealth < maxHealth)
            inCombat = true;
    }

    public abstract void Attack();

    protected void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        audioSource.PlayOneShot(getHitSound);
        animator.SetTrigger("GetHit");
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
