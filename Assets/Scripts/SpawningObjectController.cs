using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningObjectController : MonoBehaviour
{
    [SerializeField]
    int[] spawningPoints;

    [SerializeField]
    float speed = 50.0F;

    Rigidbody2D _rb;
    SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = FindAnyObjectByType<SpawnManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.velocity = Vector2.left * speed * Time.fixedDeltaTime * _spawnManager.GetSpeedMultiplier();
    }

    public int[] GetSpawningPoints()
    {
        return spawningPoints;
    }
}
