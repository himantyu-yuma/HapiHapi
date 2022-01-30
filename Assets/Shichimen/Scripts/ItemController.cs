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
        //�^�O�̖��O�͉��ł�
        if (collision.gameObject.tag == "Player")
        {
            // �Ƃ肠�����񕜏������L�ځi����Player���ł���Ă�j
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