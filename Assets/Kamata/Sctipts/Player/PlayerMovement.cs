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
        _dashPower = Variables.Object(gameObject).Get<float>("DashPower");
        _dashAction.started += OnDashPressed;
        _moveAction.performed += OnChangeDirection;
    }

    private void OnChangeDirection(InputAction.CallbackContext obj)
    {
        _currentDirection = obj.ReadValue<Vector2>().normalized;
    }

    private void OnDashPressed(InputAction.CallbackContext obj)
    {
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
            _rigidbody2D.velocity = input * _playerSpeed * Time.deltaTime;
        }
    }
}
