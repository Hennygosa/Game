using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatRanged : MonoBehaviour
{
    Rigidbody rb;
    public Transform attackPoint;
    public GameObject target;
    public GameObject projectile;

    public float attackRange = 15f;
    public int attackDamage = 40;
    public float bulletSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //play an attack animation

        //spawn the projectile
        Rigidbody bullet = Instantiate(projectile, attackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

}
