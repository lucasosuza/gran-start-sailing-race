using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Canvas messageCanvas;
    public GameObject gameMenu;
    public TextMeshProUGUI foundText;
    public TextMeshProUGUI crashText;

    // Start is called before the first frame update
    void Start()
    {
        messageCanvas.enabled = false;
        foundText.enabled = false;
        crashText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void Crash() 
    {
        messageCanvas.enabled = true;
        crashText.enabled = true;
    }

    internal void Win()
    {
        messageCanvas.enabled = true;
        foundText.enabled = true;
        
    }
}
