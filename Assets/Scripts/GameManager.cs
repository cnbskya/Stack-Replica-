using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject SpawnCube;
    public GameObject lastCube;
    public GameObject mainCamera;
    public Text scoreText;

    public bool isLeft;
    public bool isGameOn;
    public int score = 1;
    public float level;


    private void Awake()
    {
        instance = this;
    }

    public void StartSpawnCube()
    {
        SpawnCube = Instantiate(SpawnCube);
        SpawnCube.GetComponent<MovingCube>().color = Color.HSVToRGB((level * 0.1f), 1f, 1f);
    }
    private void StopMoving()
    {
        FindObjectOfType<MovingCube>().moveSpeed = 0;
        SpawnCube.GetComponent<MovingCube>().DroppingObjectSize();
        isLeft = !isLeft;
        lastCube = SpawnCube;
        SpawnCube = Instantiate(SpawnCube);
        ScoreIncrement();
        StartCoroutine(CameraMove(new Vector3(3, 4, 3) + new Vector3(0, level, 0)));
        SpawnCube.GetComponent<MovingCube>().color = Color.HSVToRGB((level * 0.15f), 1f, 1f);
        FindObjectOfType<MovingCube>().moveSpeed = 2f;
    }

    public void OnMouseDownEvent()
    {
        StopMoving();
    }

    public void ScoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
    }

    IEnumerator CameraMove(Vector3 target)
    {
        while (Vector3.Distance(Camera.main.transform.position, target) > 0.1f)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}