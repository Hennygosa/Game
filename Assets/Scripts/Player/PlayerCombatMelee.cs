using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatMelee : MonoBehaviour
{
    public Transform attackPoint;
    //слой для регистрации попаданий по врагам
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //анимация удара

        //определяем попадания по объектам из слоя
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //нанести урон
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
