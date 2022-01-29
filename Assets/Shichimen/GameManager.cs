using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    GameObject player;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("");
        this.enemy = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) GameExit();
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GameExit()
    {

      UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
    }
    
}