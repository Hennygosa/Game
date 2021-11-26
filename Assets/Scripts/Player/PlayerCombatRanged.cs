using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatRanged : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject target;
    public GameObject projectile;
    public RadialBar radialBar;

    public float attackRange = 15f;
    public int attackDamage = 40;
    public float bulletSpeed = 30f;
    public int maxAmmo = 5;
    public int currentAmmo;
    public float reloadTime = 1f;

    private bool isReloading = false;
    private float timer;
    
    void Start()
    {
        timer = reloadTime;
        radialBar.maxValue = maxAmmo;
        radialBar.amount.text = $"{maxAmmo}";
        currentAmmo = maxAmmo;
        radialBar.currentValue = currentAmmo;
    }

    void Update()
    {
        //��������� ������� �����������
        if (isReloading)
        {
            radialBar.maxValue = reloadTime;
            timer -= Time.deltaTime;
            radialBar.Modify(timer);
            radialBar.amount.text = "";
            return;
        }
        //����������� ��� 0 �������� ��� �� R
        if (currentAmmo <= 0f || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
        //������� �� ���
        if(Input.GetKeyDown(KeyCode.Mouse1))
            Shoot();
    }

    public void Shoot()
    {
        //�������� ��������

        //������� ���� � ����������� �������
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
        timer = reloadTime;
        isReloading = false;
    }
}
