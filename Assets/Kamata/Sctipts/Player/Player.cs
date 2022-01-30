using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameManager manager = null;

    [SerializeField]
    private float threshold = 70;

    private float _playerHp;
    public float PlayerHp
    {
        get => _playerHp;
        set
        {
            _playerHp = value;
            if (_playerHp < 0)
            {
                _playerHp = 0;
                // TODO: Gameover
                manager?.GameOver();
            }
            else if (_playerHp >= threshold)
            {
                IsLarge = true;
            }
            else if (_playerHp < threshold)
            {
                IsLarge = false;
            }
            else if (_playerHp > maxHp)
            {
                _playerHp = maxHp;
            }
            // TODO: update UI text?

        }
    }

    private bool _isLarge;
    public bool IsLarge
    {
        get => _isLarge;
        set
        {
            _isLarge = value;
            Variables.Object(gameObject).Set("IsLarge", _isLarge);
        }
    }

    [SerializeField] private float maxHp = 100f;

    private void Awake()
    {
        _playerHp = threshold - 1;
        _isLarge = false;
    }

    public void Damaged<T>(float damage, T context)
    {
        // TODO: Do something
        PlayerHp -= damage;
    }
}
