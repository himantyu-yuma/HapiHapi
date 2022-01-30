using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _dashAction;
    private Rigidbody2D _rigidbody2D;
    private float _playerSpeed;
    private float _dashPower;
    private Vector2 _currentDirection = new(1f, 0f);
    private float _elapsedTime;
    [SerializeField] private float moveForceMultiplier = 1f;
    [SerializeField] private Sprite faceSpriteNormal;
    [SerializeField] private Sprite faceSpriteNormalGoingDown;
    private SpriteRenderer _faceSpriteRendererNormal;
    private SpriteRenderer _faceSpriteRendererLarge;
    
    public bool IsDash { get; set; }

    private void Awake()
    {
        TryGetComponent(out _player);
        TryGetComponent(out _rigidbody2D);
        TryGetComponent(out _playerInput);
        _moveAction = _playerInput.actions["Move"];
        _dashAction = _playerInput.actions["Dash"];
    }

    private void Start()
    {
        _playerSpeed = Variables.Object(gameObject).Get<float>("Speed");
        _dashAction.started += OnDashPressed;
        _moveAction.performed += OnChangeDirection;
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
    }
}
