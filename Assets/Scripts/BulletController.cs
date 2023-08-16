using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]
    float damage = 50.0F;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController controller = GetComponent<Collider>().GetComponent<HealthController>();
        if (controller != null)
        {
            controller.TakeDamage(damage);
        }
    }
}
