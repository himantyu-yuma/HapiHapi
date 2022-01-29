using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public  bool Hostility = false; //�G�ӂ̐؂�ւ�
    private Enemy nearObj;

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
        
        if (other.gameObject.tag == "Player")//�G�Ӕ���
        {
            isHostility();
            nearObj = serchTag(gameObject);
            nearObj.Hostility = true;
                
            
        }

        if (other.gameObject.tag == "Bullet")//����
        {
            Vanish();
        }
    }
    
    Enemy serchTag(GameObject nowObj)
    {
        float tmpDis = 0;           
        float nearDis = 0;          
        Enemy targetObj = null; 
        
        foreach (Enemy obs in GameObject.FindObjectsOfType<Enemy>())
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
