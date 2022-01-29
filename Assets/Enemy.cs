using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public  bool Hostility = false; //ìGà”ÇÃêÿÇËë÷Ç¶
    
    
    public void isHostility()
    {
        Hostility = true;
    }

    private void Vanish()
    {
        Destroy(gameObject,0.0f);//0ïbå„Ç…è¡ñ≈
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "player")//ìGà”îªíË
        {
            isHostility();
        }

        if (other.gameObject.tag == "Bullet")//è¡ñ≈
        {
            Vanish();
        }
    }


}
