using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.VFX;


public class Enemy : MonoBehaviour, IDamagable
{
    private Enemy nearObj;
    private float propagationDist = 10;

    //public void isHostility()
    //{
    //    Hostility = true;
    //}
    [SerializeField]
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
                //nearObj = serchTag(gameObject);
                //nearObj.IsHostility = true;
                //this.PropagateHostility();
            }
            this._isHostility = value;
        }
    }

    protected virtual void Attack(IDamagable target)
    {

    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
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

    protected void PropagateHostility()
    {
        var hits = Physics2D.OverlapCircleAll(this.transform.position, propagationDist, LayerMask.GetMask("Enemy"))
            .Select(item => item.transform.GetComponent<Enemy>());
        foreach (var hit in hits)
        {
            hit.IsHostility = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, propagationDist);
    }

    public void Damaged<T>(float damage, T context)
    {
        Destroy(gameObject, 0.0f);//0ïbå„Ç…è¡ñ≈
    }
}
