using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : Player
{
    
    GameObject image;
    void Start()
    {
        image = GameObject.Find("BarTop");
    }

    // Update is called once per frame
    void Update()
    {
        float _hp = PlayerHp;
        image.GetComponent<Image>().fillAmount = PlayerHp / 100;
        
    }
}
