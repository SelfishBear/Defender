using System.Collections;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable, IDieable
{
    [SerializeField] private int _enemyHealth = 5;
    [SerializeField] private int _enemyDamage = 1;
    [SerializeField] public PlayerHealth _playerHealth;
    private float _damageCooldown = 1.5f;
    private float _nextDamageTime = 0;
    public static event Action OnEnemyDeath;
    
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time > _nextDamageTime)
        {
            _playerHealth.TakeDamage(_enemyDamage);
            _nextDamageTime = Time.time + _damageCooldown;
        }
    }

    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
        if (_enemyHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnEnemyDeath?.Invoke();
        Destroy(gameObject);
    }
}
