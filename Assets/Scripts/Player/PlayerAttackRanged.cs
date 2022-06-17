using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRanged : PlayerAttack
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private int maxAmmo = 5;
    [SerializeField] private float reloadTime = 1f;

    private RadialBar radialBar;
    private int currentAmmo;
    private bool isReloading = false;
    private float reloadTimer = 0;

    void Start()
    {
        radialBar = GameObject.Find("Ammo").GetComponent<RadialBar>();
        radialBar.maxValue = maxAmmo;
        radialBar.amount.text = $"{maxAmmo}";
        currentAmmo = maxAmmo;
        radialBar.currentValue = currentAmmo;
    }

    void Update()
    {
        //show reload timer
        if (isReloading)
        {
            DisplayReloadingProgress();
            return;
        }
        //reload on 0 ammo or if R key is pressed
        if (currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            attackTimer = 0;
            return;
        }
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && attackTimer <= 0)
        {
            StartCoroutine(Attack());
            attackTimer = attackCooldown;
        }
    }

    protected override IEnumerator Attack()
    {
        audioSource.PlayOneShot(attackSound, 0.5f);
        Rigidbody bullet = Instantiate(projectile, attackPoint.transform.position, transform.localRotation).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        currentAmmo--;
        radialBar.Modify(currentAmmo);
        yield return new WaitForSeconds(0);
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
    private void DisplayReloadingProgress()
    {
        radialBar.maxValue = reloadTime;
        reloadTimer -= Time.deltaTime;
        radialBar.Modify(reloadTimer);
        radialBar.amount.text = "";
    }
}
