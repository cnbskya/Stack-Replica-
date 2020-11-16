using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject SpawnCube;
    public GameObject lastCube;
    public GameObject mainCamera;
    public bool isLeft;
    
    public float level;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnCube = Instantiate(SpawnCube);
        SpawnCube.GetComponent<MovingCube>().color = Color.HSVToRGB((level*0.1f), 1f, 1f);
        //SpawnCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((level), 1f, 1f));
    }

    private void StopMoving()
    {
        FindObjectOfType<MovingCube>().moveSpeed = 0;
        SpawnCube.GetComponent<MovingCube>().DroppingObjectSize();
        isLeft = !isLeft;
        lastCube = SpawnCube;
        SpawnCube = Instantiate(SpawnCube);
        StartCoroutine(CameraMove(new Vector3(3, 4, 3) + new Vector3(0, level, 0)));
        SpawnCube.GetComponent<MovingCube>().color = Color.HSVToRGB((level*0.1f), 1f, 1f);
        //SpawnCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((level), 1f, 1f));
        
        FindObjectOfType<MovingCube>().moveSpeed = 1.5f;
    }
    public void OnMouseDownEvent()
    {
        StopMoving();
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