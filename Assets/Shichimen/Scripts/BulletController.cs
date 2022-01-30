using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    [SerializeField]
    private int atkPower = 10;


    public AudioClip BulletHitSE;

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
        Debug.Log(collision.name);
        if (collision.TryGetComponent<IDamagable>(out var target))
        {
            SoundManager.Instance.PlaySE(BulletHitSE);
            target.Damaged(atkPower, this);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}