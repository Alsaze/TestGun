using System;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class Enemy : Character
{
    //кастыльное решение с рандомизацией позиции врага из за нехватки времени !!!
    private Vector3Int newPosition = new Vector3Int(0, 0, 0);

    [SerializeField] private EnemySpawner _enemySpawner;
    // [SerializeField] private GameObject enemySpawner;

    private void Start()
    {
        MoveSpeed = ConfigManager.MoveSpeedEnemie;
        newPosition = _enemySpawner.GetIsometricPosition();
        transform.LookAt(newPosition,transform.up);
    }

    private void FixedUpdate()
    {
        Movment();
    }

    private void Die()
    {
        ConfigManager.Score += 100;
        ConfigManager.Gold += 1;

        int index = ConfigManager.Enemy.IndexOf(gameObject);
        ConfigManager.Enemy.RemoveAt(index);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HpCharacter -= ConfigManager.FireDamage;
            if (HpCharacter <= 0)
            {
                Die();
            }
        }
    }

    private void Movment()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition,
            MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,newPosition)<=0.1f)
        {
            newPosition = _enemySpawner.GetIsometricPosition();
            transform.LookAt(newPosition,transform.up);
        }

        //Character.cs => Animator
        _isWalking = transform.position != newPosition ? _isWalking = true : _isWalking = false;
        IsWalking(_isWalking);
    }
}
