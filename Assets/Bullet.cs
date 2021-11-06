using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private int damage;
    public float speed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        damage = GameObject.Find("Enemy").GetComponent<EnemyCombatRanged>().attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("DeleteBullets", 5, 5);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log(damage);
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
