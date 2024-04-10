using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] public int bulletDamage = 5;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shootClip;
    private bool canShoot = true;
    private float bulletDirection; 
    private PlayerMovement playerMovement; 
    public Transform bulletShootPos;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (playerMovement.lastMoveDirection != 0)
        {
            bulletDirection = playerMovement.lastMoveDirection;
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        
        GameObject bullet = PlayerAmmo.instance.GetPooledObject();
        if (bullet != null)
        {
            _audioSource.PlayOneShot(_shootClip);
            bullet.transform.position = bulletShootPos.position; 
            bullet.SetActive(true);
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent._playerWeapon = this;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(bulletDirection, 0) * _bulletSpeed; 

            SpriteRenderer bulletSpriteRenderer = bullet.GetComponent<SpriteRenderer>();
            if (bulletDirection < 0)
            {
                bulletSpriteRenderer.flipX = true;
            }
            else
            {
                bulletSpriteRenderer.flipX = false;
            }
        }
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}