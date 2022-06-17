using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 40;

    [SerializeField] protected GameObject attackPoint;
    [SerializeField] protected AudioClip attackSound;
    [SerializeField] protected float attackRange = 0.5f;
    [SerializeField] protected float attackCooldown = 1f;

    protected AudioSource audioSource;
    protected float attackTimer = 0;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected abstract IEnumerator Attack();
}
