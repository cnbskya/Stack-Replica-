using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public GameObject startMenuUI;
    public GameObject gameInUI;
    public GameObject GameOverUI;
    public bool uıIsActif;
    private Scene _scene;
    

    private void Start()
    {
        instance = this;
        _scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && uıIsActif)
        {
            GameManager.instance.isGameOn = true;
            ResumeGame();
            uıIsActif = false;
            GameManager.instance.StartSpawnCube();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.isGameOn)
            {
                GameManager.instance.OnMouseDownEvent();
            }
        }
    }
    public void RestartGameButton()
    {
        Application.LoadLevel("SampleScene");
    }
    void ResumeGame()
    {
        startMenuUI.SetActive(false);
        gameInUI.SetActive(true);
    }
}