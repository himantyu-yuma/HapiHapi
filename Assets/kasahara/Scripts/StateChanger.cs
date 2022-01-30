using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class StateChanger : MonoBehaviour
{
    [SerializeField]
    private string state = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Variables.Application.Set(state, true);
        }
    }
}
