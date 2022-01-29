using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : Enemy
{

    public float speed = 0.01f;//敵の追うスピード
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
        PlayerPosition = GameObject.FindWithTag("Player");
        transform.position =Vector3.MoveTowards(transform.position, PlayerPosition.transform.position, speed);

        Quaternion rotation = this.transform.localRotation;
        if (transform.position.x < PlayerPosition.transform.position.x)
        {
            rotation.y = 180.0f;
        }
        else
        {
            rotation.y = 0.0f;
        }
        this.transform.localRotation = rotation;
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

    

