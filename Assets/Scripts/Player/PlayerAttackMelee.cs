using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : PlayerAttack
{
    [SerializeField] private LayerMask enemyLayers;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackTimer <= 0)
        {
            StartCoroutine(Attack());
            attackTimer = attackCooldown;
        }
    }

    protected override IEnumerator Attack()
    {
        audioSource.PlayOneShot(attackSound, 0.5f);
        animator.Play("NormalAttack01_SwordShield");
        //check if enemy is in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.transform.position, attackRange, enemyLayers);
        //inflict damage after animation
        yield return new WaitForSeconds(.2f);
        foreach (Collider enemy in hitEnemies)
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
