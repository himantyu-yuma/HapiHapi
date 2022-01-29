using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //IDamageble damageble;
    public float speed;

    float delta = 0.0f;
    float span = 0.05f;

    void Start()
    {
        speed = 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        //何故かは不明ですが直接Updateにおいても上手く動かないのでこうしました
        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0;
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //damageble.;
        Destroy(gameObject);
    }
}