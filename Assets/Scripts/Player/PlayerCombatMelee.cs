using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMelee : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    //���� ��� ����������� ��������� �� ������
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
        //�������� �����
        animator.Play("NormalAttack01_SwordShield");

        //���������� ��������� �� �������� �� ����
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //������� ����
        yield return new WaitForSeconds(.4f);
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
