using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Enemy _enemy;
    [SerializeField] public PlayerWeapon _playerWeapon;
    
    private void OnEnable()
    {
        // Запускаем корутину удаления пули через 1.5 секунды после активации
        StartCoroutine(DisableBulletAfterTime(1.5f));
    }

    private IEnumerator DisableBulletAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Touched");
            _enemy = collision.gameObject.GetComponent<Enemy>();
            if (_enemy != null && _playerWeapon != null)
            {
                _enemy.TakeDamage(_playerWeapon.bulletDamage);
                gameObject.SetActive(false);
            }
        }
    }
}