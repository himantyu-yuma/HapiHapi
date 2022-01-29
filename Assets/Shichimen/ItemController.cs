using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    SoundManager soundManager;
    public int ItemEnergy;
    AudioClip itemSE;

    float delta = 0.0f;
    float span = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //タグの名前は仮です
        if (collision.gameObject.tag == "Player")
        {
            soundManager.PlaySE(itemSE);
            Destroy(gameObject);
        }
    }
    //Update is called once per frame
    void Update()
    {
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



}