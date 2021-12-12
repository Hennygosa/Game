using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private int damage;
    public float speed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        damage = GameObject.FindGameObjectWithTag("EnemyRanged").GetComponent<EnemyCombat>().attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("DeleteBullets", 5, 5);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            target.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void DeleteBullets()
    {
        Destroy(gameObject);
    }
}
