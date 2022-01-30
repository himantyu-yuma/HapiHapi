using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public  bool Hostility ; //�G�ӂ̐؂�ւ�
    private Enemy nearObj;

    

    public void Vanish()
    {
        
        Destroy(gameObject.transform.root.gameObject);
        Destroy(gameObject,0.0f);//0�b��ɏ���
        
    }


    

    public void isHostility()
    {
        Hostility = true;
        nearObj = serchTag(gameObject);
        nearObj.Hostility = true;
    }

    Enemy serchTag(GameObject nowObj)//�G�ӂ̓`�d
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
