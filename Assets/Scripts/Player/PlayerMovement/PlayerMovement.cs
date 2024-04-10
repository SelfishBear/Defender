using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly string RUN = "Run";
    [SerializeField] private float _speed = 5.0f;
    private Animator _animator;
    public float lastMoveDirection;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2d;
    private PlayerWeapon _playerWeapon;

    private void Start()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        if (horizontalInput != 0)
        {
            _animator.SetBool(RUN, true);
            lastMoveDirection = horizontalInput;
            if (lastMoveDirection < 0)
            {
                _playerWeapon.bulletShootPos.localPosition = new Vector3(-Mathf.Abs(_playerWeapon.bulletShootPos.localPosition.x), _playerWeapon.bulletShootPos.localPosition.y, _playerWeapon.bulletShootPos.localPosition.z);
            }
            else
            {
                _playerWeapon.bulletShootPos.localPosition = new Vector3(Mathf.Abs(_playerWeapon.bulletShootPos.localPosition.x), _playerWeapon.bulletShootPos.localPosition.y, _playerWeapon.bulletShootPos.localPosition.z);
            }
        }
        else
        {
            _animator.SetBool(RUN, false);
        }
        _spriteRenderer.flipX = lastMoveDirection <= 0;
        _rb2d.velocity = moveDirection * _speed;
    }
}