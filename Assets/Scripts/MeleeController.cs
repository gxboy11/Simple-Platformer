using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeController : MonoBehaviour
{
    readonly object _lock = new object();
    static MeleeController _instance;

    public static MeleeController Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float damage = 50.0F;

    [HideInInspector]
    public UnityEvent onAttack; //notificara cuando ha ocurrido un ataque

    float _nextAttackTime = 0.0F;

    private void Awake()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = this;
                }
            }
        }
        onAttack.AddListener(OnAttack);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _nextAttackTime)
        {
            animator.SetTrigger("melee");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    private void OnAttack()
    {
        animator.ResetTrigger("melee");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (Collider2D collider in colliders)
        {
            HealthController controller = collider.GetComponent<HealthController>();
            if (controller != null)
            {
                controller.TakeDamage(damage);
            }
        }

    }
}
