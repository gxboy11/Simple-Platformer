using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField]
    Vector2 speed = Vector2.zero;

    Material _material;

    Vector2 _offset;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        Vector2 offset = speed * Time.deltaTime;
        _material.mainTextureOffset += offset;
    }
}
