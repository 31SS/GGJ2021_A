﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject pauseMenu;    //ポーズメニュー
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //ポーズボタン
    public void ClickPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
