using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMelee : MonoBehaviour
{
    public Animator animator;
    public AudioClip meleeSound;
    public Transform attackPoint;
    //���� ��� ����������� ��������� �� ������
    public LayerMask enemyLayers;

    public float attackCooldown = 1f;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    private AudioSource audioSource;
    private float attackTimer;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(meleeSound, 0.4f);
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
