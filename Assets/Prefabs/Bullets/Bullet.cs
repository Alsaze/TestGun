using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _shotDirection;
    public void Setup(Vector3 shotDirecton)
    {
        _shotDirection = shotDirecton;
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        float speed = 5f;
        transform.position += _shotDirection * Time.deltaTime * speed;
    }
}
