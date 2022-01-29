using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamagable
{
    public bool Hostility = false; //ìGà”ÇÃêÿÇËë÷Ç¶
    private Enemy nearObj;

    //public void isHostility()
    //{
    //    Hostility = true;
    //}
    private bool _isHostility = false;
    public bool IsHostility
    {
        get
        {
            return this._isHostility;
        }
        set
        {
            if (value == true)
            {
                nearObj = serchTag(gameObject);
                nearObj.Hostility = true;
            }
            this._isHostility = value;
        }
    }

    protected virtual void Attack(IDamagable target)
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("became enemy");


    //    if (other.tag == "Player")//ìGà”îªíË
    //    {
    //        isHostility();
    //        nearObj = serchTag(gameObject);
    //        nearObj.Hostility = true;
    //    }
    //}

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

    public void Damaged<T>(float damage, T context)
    {
        Destroy(gameObject, 0.0f);//0ïbå„Ç…è¡ñ≈
    }
}
