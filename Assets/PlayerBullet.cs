using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Transform target;
    private int damage;
    public float speed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        damage = GameObject.Find("Player").GetComponent<PlayerCombatRanged>().attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("DeleteBullets", 15, 15);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Projectile")
            return;
        else
            Destroy(gameObject);
    }

    private void DeleteBullets()
    {
        Destroy(gameObject);
    }
}