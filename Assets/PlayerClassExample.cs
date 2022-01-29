using System.Globalization;
using UnityEngine;

public class PlayerClassExample : MonoBehaviour
{
    private Player _player;
    
    void Start()
    {
        GameObject.FindWithTag("Player").TryGetComponent(out _player);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Damage to Player: 40"))
        {
            _player.Damaged(40f, this);
        }

        if (GUILayout.Button("Toggle IsLarge"))
        {
            _player.IsLarge = !_player.IsLarge;
        }
        GUILayout.Label(_player.PlayerHp.ToString(CultureInfo.InvariantCulture));
    }
}
