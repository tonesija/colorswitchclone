﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGameScene(){
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadAboutScene(){
        SceneManager.LoadScene("AboutScene");
    }
}
