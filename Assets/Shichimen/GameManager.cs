using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    

    enum SEs 
    {
        GetItem=0,BulletHitPlayer,BulletHitEnemy
    }

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("");
        this.enemy = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySE(int SEIndex)
    {

    }
}