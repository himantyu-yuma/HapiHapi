using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public  bool Hostility = false; //�G�ӂ̐؂�ւ�
    
    
    public void isHostility()
    {
        Hostility = true;
    }

    private void Vanish()
    {
        Destroy(gameObject,0.0f);//0�b��ɏ���
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "player")//�G�Ӕ���
        {
            isHostility();
        }

        if (other.gameObject.tag == "Bullet")//����
        {
            Vanish();
        }
    }


}
