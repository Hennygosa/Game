using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMelee : MonoBehaviour
{
<<<<<<< HEAD
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //play an attack animation

        //detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage them
=======
    public Animator animator;

    public Transform attackPoint;
    //слой для регистрации попаданий по врагам
    public LayerMask enemyLayers;

    public float attackCooldown = 1f;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    private float attackTimer;

    public void Start()
    {
        attackTimer = attackCooldown;
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

    IEnumerator Attack()
    {
        //анимация удара
        animator.Play("NormalAttack01_SwordShield");

        //определяем попадания по объектам из слоя
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //нанести урон
        yield return new WaitForSeconds(.4f);
>>>>>>> dev
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
