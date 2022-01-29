using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : Enemy
{

    public float speed = 0.2f;//敵の追うスピード
    private GameObject PlayerPosition;

    void Start()
    {
        Hostility = false;
    }

    void Update()
    {
        if (Hostility)
        {
            Move();
        }

    }

    private void Move()
    {
        PlayerPosition = GameObject.FindWithTag("player");
        transform.position =Vector3.MoveTowards(transform.position, PlayerPosition.transform.position, speed);
    }

    private void Attack()
    {
        //IDamaseble();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player"&&Hostility)//攻撃判定
        {
            Attack();
        }

        
    }
}

    

