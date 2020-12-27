﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene("MainScene");

    }

    public void QuitGame()
    {

        Debug.Log("Saiu");
        Application.Quit();

    }
}
