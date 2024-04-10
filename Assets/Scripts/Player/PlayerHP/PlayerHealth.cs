using UnityEngine;
using System;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable, IDieable
{
    private readonly string HURT = "Hurt";
    public event Action<float> OnHealthChanged;
    private float _maxHealth = 100f;
    public float _currentHealth;
    private bool _canBeImmortal = true;
    private float _immortalDuration = 1.5f;
    private float _immortalCooldown = 1f;
    private bool _isImmortal = false;
    private Animator _animator;
    [SerializeField] private GameObject _panel;
    private void Start()
    {
       _currentHealth = _maxHealth;
       _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if(!_isImmortal)
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        else if (_canBeImmortal)
        {
            StartCoroutine(Immortality());
        }
        _animator.SetBool(HURT, true);
        OnHealthChanged?.Invoke(_currentHealth);
    }

    private IEnumerator Immortality()
    {
        _isImmortal = true;
        yield return new WaitForSeconds(_immortalDuration);
        _isImmortal = false;
        _animator.SetBool(HURT, false);
        yield return new WaitForSeconds(_immortalCooldown);
        _isImmortal = true;
    }
    public void Die()
    {
        Time.timeScale = 0;
        _panel.SetActive(true);
        Destroy(gameObject);
    }
    
}



