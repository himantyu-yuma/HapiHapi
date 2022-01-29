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
        //ƒ^ƒO‚Ì–¼‘O‚Í‰¼‚Å‚·
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.Instance.PlaySE(itemSE);
            Destroy(gameObject);
        }
    }
    //Update is called once per frame
    void Update()
    {


    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}