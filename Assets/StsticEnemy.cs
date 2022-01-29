using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StsticEnemy : Enemy
{
    private GameObject PlayerTranslate;
    public GameObject bullet;//ã ÇÃê∂ê¨
   
    void Start()
    {
        Hostility = false;
    }

   
    void Update()
    {
        if (Hostility)
        {
            InvokeRepeating("Shot", 0f, 1.5f);
            
        }
    }

    private void Shot()
    {
        PlayerTranslate = GameObject.FindWithTag("play");
        var aim = this.PlayerTranslate.transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
        GameObject Bullet = Instantiate(bullet) as GameObject;
    }


}
