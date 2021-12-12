using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    private int damage;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        damage = GameObject.FindGameObjectWithTag("EnemyRanged").GetComponent<EnemyCombat>().attackDamage;
    }
    void Update()
    {
        //������� ������� ������ 5
        InvokeRepeating("DeleteBullets", 5, 5);
    }
    private void OnTriggerEnter(Collider collider)
    {
        //�������� � ������ - ������� ����
        if (collider.gameObject.CompareTag("Player"))
        {
            target.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //�������� � "�����" - ������ ��������� ������
        else if (collider.gameObject.CompareTag("EnemyRanged") || collider.gameObject.CompareTag("EnemyMelee"))
            return;
        //� ��������� - ������� ������
        else
            Destroy(gameObject);
    }

    private void DeleteBullets()
    {
        Destroy(gameObject);
    }
}
