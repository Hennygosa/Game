using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatRanged : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject target;
    public GameObject projectile;
    public RadialBar radialBar;

    public float attackCooldown = .5f;
    public float attackRange = 15f;
    public int attackDamage = 40;
    public float bulletSpeed = 30f;
    public int maxAmmo = 5;
    public int currentAmmo;
    public float reloadTime = 1f;

    private bool isReloading = false;
    private float reloadTimer;
    private float attackTimer;

    void Start()
    {
        attackTimer = attackCooldown;
        reloadTimer = reloadTime;
        radialBar.maxValue = maxAmmo;
        radialBar.amount.text = $"{maxAmmo}";
        currentAmmo = maxAmmo;
        radialBar.currentValue = currentAmmo;
    }

    void Update()
    {
        //индикатор времени перезар€дки
        if (isReloading)
        {
            radialBar.maxValue = reloadTime;
            reloadTimer -= Time.deltaTime;
            radialBar.Modify(reloadTimer);
            radialBar.amount.text = "";
            return;
        }
        //перезар€дка при 0 патронов или на R
        if (currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            attackTimer = 0;
            return;
        }
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        //выстрел по ѕ ћ
        if (Input.GetKeyDown(KeyCode.Mouse1) && attackTimer <= 0)
        {
            Shoot();
            attackTimer = attackCooldown;
        }
    }

    public void Shoot()
    {
        //анимаци€ выстрела

        //создать пулю и пересчитать патроны
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        currentAmmo--;
        radialBar.Modify(currentAmmo);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        radialBar.maxValue = maxAmmo;
        currentAmmo = maxAmmo;
        radialBar.Modify(currentAmmo);
        reloadTimer = reloadTime;
        isReloading = false;
    }
}
