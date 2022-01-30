using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    
    public int ItemEnergy;
    public AudioClip itemSE;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //タグの名前は仮です
        if (collision.gameObject.tag == "Player")
        {
            // とりあえず回復処理を記載（多分Player側でやってる）
            collision.GetComponent<IDamagable>().Damaged(-this.ItemEnergy, this);
            SoundManager.Instance.PlaySE(itemSE);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}