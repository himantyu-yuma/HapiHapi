using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgm;

    private void Awake()
    {
        SoundManager.Instance.PlayBGM(bgm);
    }
}
