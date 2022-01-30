using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StsticEnemy : Enemy
{
    private GameObject PlayerTranslate;
    public GameObject bulletPos;
    public GameObject bullet;//�ʂ̐���
    [SerializeField] private float _timeInterval;
    private float _timeElapsed = 4.0f;

   
    void Start()
    {
        Hostility = false;
    }

   
    void Update()
    {
        if (Hostility)
        {
            _timeElapsed += Time.deltaTime;

            if (_timeElapsed > _timeInterval)
            {
                Shot();

                // �o�ߎ��Ԃ����ɖ߂�
                _timeElapsed = 0.0f;
            }
            
            
        }
    }

    private void Shot()
    {
        SoundManager.Instance.PlaySE(DefaultSE);
        PlayerTranslate = GameObject.FindWithTag("Player");

        Vector3 dir = (PlayerTranslate.transform.position - this.transform.position);
        
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir);

        GameObject Bullet = Instantiate(bullet) as GameObject;
        Bullet.transform.rotation = this.transform.rotation;
       Bullet.transform.position = bulletPos.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")//�G�Ӕ���
        {
            isHostility();
        }

        if (collision.gameObject.tag == "Bullet")//����
        {
            isHostility();
            Vanish();
        }
    }


}
