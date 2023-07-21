using System;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character
{
    //кастыльное решение с рандомизацией позиции врага из за нехватки времени !!!
    private Vector3Int newPosition = new Vector3Int(0, 0, 0);
    
    private EnemySpawner _enemySpawner = new EnemySpawner();
    [SerializeField] private GameObject enemySpanwer;
    private void Start()
    {
        _enemySpawner = enemySpanwer.GetComponent<EnemySpawner>();

        // var HP = ConfigManager.Hp; //при том что пуля наносит в начале игры 1 урон
        MoveSpeed = 1f;
        newPosition = _enemySpawner.GetIsometricPosition();
    }

    private void FixedUpdate()
    {
        Movment();
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (HP <= 0)
        {
            ConfigManager.Score += 100;
            ConfigManager.Gold += 1;
            
            int index = ConfigManager.Enemy.IndexOf(gameObject);
            ConfigManager.Enemy.RemoveAt(index);
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP -= ConfigManager.FireDamage;
        }
    }

    private void Movment()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition,
            MoveSpeed * Time.deltaTime);
        //каждый раз когда мы достигаем поставленной точки, она меняеться другой
        if (transform.position == newPosition)
        {
            _enemySpawner.GetIsometricPosition();
        }
        
        //Character.cs => Animator
        _isWalking = transform.position != newPosition ? _isWalking = true : _isWalking = false;
        IsWalking(_isWalking);
    }
}

