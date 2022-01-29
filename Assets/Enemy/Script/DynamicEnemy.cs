using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : Enemy
{

    public float speed = 0.01f;//敵の追うスピード
    private GameObject PlayerPosition;

    [SerializeField]
    private int AtkPower = 10;

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
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition.transform.position, speed);

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

    protected override void Attack(IDamagable target)
    {

        target.Damaged<Enemy>(AtkPower, this);
    }



    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Hostility)//攻撃判定
        {
            Attack(other.gameObject.GetComponent<IDamagable>());
        }
        else if (other.tag == "Player")
        {
            IsHostility = true;
        }
    }

}



