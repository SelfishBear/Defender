using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private Slider _healthSlider;

    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void Start()
    {
        _healthSlider = GetComponent<Slider>(); 
        _healthSlider.value = _playerHealth._currentHealth;  
    }

    private void UpdateHealthBar(float health)
    {
        _healthSlider.value = health;
    }
   
}