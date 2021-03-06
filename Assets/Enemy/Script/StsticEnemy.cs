using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StsticEnemy : Enemy
{
    private GameObject PlayerTranslate;
    [SerializeField]
    private GameObject bulletPos;
    [SerializeField]
    private Transform bulletBox;
    [SerializeField]
    private GameObject bullet;//玉の生成
    [SerializeField] private float _timeInterval = 4;
    private float _timeElapsed = 0;


    void Start()
    {
        IsHostility = false;
    }


    void Update()
    {
        if (IsHostility)
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed > _timeInterval)
            {
                Shot();

                // 経過時間を元に戻す
                _timeElapsed = 0.0f;
            }


        }
    }

    private void Shot()
    {
        PlayerTranslate = GameObject.FindWithTag("Player");

        Vector3 dir = (PlayerTranslate.transform.position - bulletBox.position);

        bulletBox.rotation = Quaternion.FromToRotation(Vector3.right, dir);

        GameObject Bullet = Instantiate(bullet) as GameObject;
        Bullet.transform.rotation = bulletBox.rotation;
        Bullet.transform.position = bulletPos.transform.position;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")//敵意判定
        {
            IsHostility = true;
            base.PropagateHostility();
        }
    }


}
