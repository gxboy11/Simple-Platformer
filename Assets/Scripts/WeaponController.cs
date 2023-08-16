using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    readonly object _lock = new object();
    static WeaponController _instance;

    public static WeaponController Instance
    {
        get
        {
            return _instance;
        }
    }



    [SerializeField]
    Transform firepoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletSpeed = 100.0F;

    [SerializeField]
    float bulletLifeTime = 5.0F;

    [SerializeField]
    int fireRate = 3;

    [SerializeField]
    Animator animator;

    float _nextFireTime = 0;

    [HideInInspector]
    public UnityEvent onFire;

    private void Start()
    {
        onFire.AddListener(OnFire);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire2") && Time.time > _nextFireTime)
        {
            _nextFireTime = Time.time + 1.0F / fireRate; //Cooldown
            animator.SetTrigger("fire");
        }
    }

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
    }
    void OnFire()
    {
        animator.ResetTrigger("fire");
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity); //Crea la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed * Time.deltaTime; //La bala avanza

        Destroy(bullet, bulletLifeTime); //Tiempo de vida de la bala

    }
}
