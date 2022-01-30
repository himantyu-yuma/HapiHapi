using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _dashAction;
    private InputAction _shotAction;
    private Rigidbody2D _rigidbody2D;
    private float _playerSpeed;
    private float _dashPower;
    private ParticleSystem _fireParticle;
    private Collider2D _fireCol;
    private Vector2 _currentDirection = new(1f, 0f);
    private float _elapsedTime;
    [SerializeField] private float moveForceMultiplier = 1f;
    [SerializeField] private Sprite faceSpriteNormal;
    [SerializeField] private Sprite faceSpriteNormalGoingDown;
    private SpriteRenderer _faceSpriteRendererNormal;
    private SpriteRenderer _faceSpriteRendererLarge;

    public bool IsDash { get; set; }
    public bool IsShot { get; set; }

    private void Awake()
    {
        TryGetComponent(out _player);
        TryGetComponent(out _rigidbody2D);
        TryGetComponent(out _playerInput);
        _moveAction = _playerInput.actions["Move"];
        _dashAction = _playerInput.actions["Dash"];
        _shotAction = _playerInput.actions["Shot"];
    }

    private void Start()
    {
        _playerSpeed = Variables.Object(gameObject).Get<float>("Speed");
        _dashPower = Variables.Object(gameObject).Get<float>("DashPower");
        _fireParticle = Variables.Object(gameObject).Get<ParticleSystem>("Fire");
        _fireCol = Variables.Object(gameObject).Get<Collider2D>("FireCol");
        _dashAction.started += OnDashPressed;
        _moveAction.performed += OnChangeDirection;
        _shotAction.started += OnShotPressed;
        _shotAction.canceled += OnShotReleased;
        foreach (var spriteRenderer in GetComponentsInChildren<SpriteRenderer>(true))
        {
            switch (spriteRenderer.name)
            {
                case "FireBall_Face":
                    _faceSpriteRendererNormal = spriteRenderer;
                    break;
                case "FireBall_Face_Big":
                    _faceSpriteRendererLarge = spriteRenderer;
                    break;
            }
        }

    }

    private void OnChangeDirection(InputAction.CallbackContext obj)
    {
        _currentDirection = obj.ReadValue<Vector2>().normalized;
        // going down
        _faceSpriteRendererNormal.sprite = _currentDirection.y < 0 ? faceSpriteNormalGoingDown : faceSpriteNormal;

        if (_currentDirection.x < 0)
        {
            _faceSpriteRendererNormal.flipX = true;
            _faceSpriteRendererLarge.flipX = true;
        }
        else if (_currentDirection.x > 0)
        {
            _faceSpriteRendererNormal.flipX = false;
            _faceSpriteRendererLarge.flipX = false;
        }
    }

    private void OnDashPressed(InputAction.CallbackContext obj)
    {
        _dashPower = Variables.Object(gameObject).Get<float>("DashPower");
        IsDash = true;
        _elapsedTime = _dashPower;
    }

    private void OnShotPressed(InputAction.CallbackContext obj)
    {
        if (_player.IsLarge)
        {
            _fireParticle.Play();
            _fireCol.enabled = true;
            IsShot = true;
        }
    }

    private void OnShotReleased(InputAction.CallbackContext obj)
    {
        _fireParticle.Stop();
        _fireCol.enabled = false;
        IsShot = false;
    }

    private void RotateFire()
    {
        _fireParticle.transform.rotation = Quaternion.FromToRotation(Vector3.right, _currentDirection);
    }

    private void FixedUpdate()
    {
        if (IsDash)
        {
            _rigidbody2D.velocity = _currentDirection * 10;
            _elapsedTime -= Time.deltaTime * 1000;
            if (_elapsedTime < 0)
            {
                IsDash = false;
            }
        }
        else
        {
            var input = _moveAction.ReadValue<Vector2>();
            var vector = input * _playerSpeed * Time.deltaTime;
            var velocity = _rigidbody2D.velocity;
            _rigidbody2D.AddForce(moveForceMultiplier * (vector*2 - velocity*2), ForceMode2D.Force);
        }

        RotateFire();
        if (IsShot)
        {
            _player.Damaged(Time.fixedDeltaTime * 2, this);
            if (!_player.IsLarge)
            {
                _fireParticle.Stop();
                _fireCol.enabled = false;
                IsShot = false;
            }
        }
    }
}