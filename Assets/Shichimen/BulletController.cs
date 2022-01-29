using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //IDamageble damageble;
    public float speed;

    
    public AudioClip BulletHitEnemy;
    public AudioClip BulletHitPlayer;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SoundManager.Instance.PlaySE(BulletHitPlayer);
        }
        else if(collision.gameObject.tag=="Enemy")
        {
            Debug.Log("Hit");
            SoundManager.Instance.PlaySE(BulletHitEnemy);
        }
        //damageble.;
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}