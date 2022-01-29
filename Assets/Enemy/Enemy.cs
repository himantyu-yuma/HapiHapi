using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public  bool Hostility = false; //�G�ӂ̐؂�ւ�
    private GameObject nearObj;

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
            nearObj = serchTag(gameObject);
            nearObj.Enemy.Hostility = true;
        }

        if (other.gameObject.tag == "Bullet")//����
        {
            Vanish();
        }
    }

    GameObject serchTag(GameObject nowObj)
    {
        float tmpDis = 0;           
        float nearDis = 0;          
        GameObject targetObj = null; 
        
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);
            
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = obs;
            }
        }
        
        return targetObj;
    }

}
