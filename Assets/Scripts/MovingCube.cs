using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public GameObject startCube;
    public float moveSpeed = 2f;
    public Color color;
    public bool isPos = true;
    public bool isGameOn;

    private void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
        GameManager.instance.level += 0.1f;
        if (GameManager.instance.isLeft)
        {
            Vector3 leftPosition = new Vector3(GameManager.instance.lastCube.transform.position.x,
                GameManager.instance.level, -2.5f);
            transform.position = leftPosition;
        }
        else
        {
            Vector3 rightPosition = new Vector3(-2.5f, GameManager.instance.level,
                GameManager.instance.lastCube.transform.position.z);
            transform.position = rightPosition;
        }
    }

    private void Update()
    {
        MovementCube();
    }

    public void MovementCube()
    {
        if (GameManager.instance.isLeft)
        {
            if (transform.position.z < 1.3 && isPos)
            {
                transform.position += transform.forward * Time.deltaTime * moveSpeed;
            }
            else isPos = false;

            if (transform.position.z >= -1.3f && isPos == false)
            {
                transform.position += transform.forward * -1 * Time.deltaTime * moveSpeed;
            }
            else isPos = true;
        }
        else
        {
            if (transform.position.x < 1.3 && isPos)
            {
                transform.position += transform.right * Time.deltaTime * moveSpeed;
            }
            else isPos = false;

            if (transform.position.x >= -1.3f && isPos == false)
            {
                transform.position += transform.right * -1 * Time.deltaTime * moveSpeed;
            }
            else isPos = true;
        }
    }

    public void DroppingObjectSize()
    {
        startCube = GameManager.instance.lastCube;

        // -------------------------- SOLDAN GELME DURUMU --------------------------- //
        if (GameManager.instance.isLeft)
        {
            if (gameObject.transform.position.z > startCube.transform.position.z)
            {
                if (gameObject.transform.position.z > startCube.transform.position.z + transform.localScale.z)
                {
                    gameObject.AddComponent<Rigidbody>();
                    return;
                }

                float fark = Mathf.Abs(startCube.transform.position.z - gameObject.transform.position.z);
                GameObject droppingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                droppingCube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fark);
                droppingCube.transform.position = startCube.transform.position +
                                                  Vector3.forward * (fark / 2 + startCube.transform.localScale.z / 2) +
                                                  Vector3.up * startCube.transform.lossyScale.y;
                droppingCube.AddComponent<Rigidbody>(); //.drag = 16; // TEST 
                droppingCube.GetComponent<BoxCollider>(); //.enabled = false; // TEST
                droppingCube.GetComponent<Renderer>().material.SetColor("_Color", color);

                Destroy(droppingCube, 1f);

                Vector3 remainingScale = gameObject.transform.localScale;
                remainingScale.z -= fark;
                transform.localScale = remainingScale;
                transform.position += Vector3.back * fark / 2;
            }

            if (gameObject.transform.position.z < startCube.transform.position.z)
            {
                if (gameObject.transform.position.z < startCube.transform.position.z - transform.localScale.z)
                {
                    gameObject.AddComponent<Rigidbody>();
                    return;
                }

                float fark = Mathf.Abs(startCube.transform.position.z - gameObject.transform.position.z);
                GameObject droppingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                droppingCube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fark);
                droppingCube.transform.position = startCube.transform.position +
                                                  Vector3.back * (fark / 2 + startCube.transform.localScale.z / 2) +
                                                  Vector3.up * startCube.transform.lossyScale.y;
                droppingCube.AddComponent<Rigidbody>(); //.drag = 16; // TEST 
                droppingCube.GetComponent<BoxCollider>(); //.enabled = false; // TEST

                droppingCube.GetComponent<Renderer>().material.SetColor("_Color", color);

                Destroy(droppingCube, 1f);

                Vector3 remainingScale = gameObject.transform.localScale;
                remainingScale.z -= fark;
                transform.localScale = remainingScale;
                transform.position += Vector3.forward * fark / 2;
            }
        }
        else
        {
            // ---------------------- SAĞDAN GELME DURUMU ------------------------------
            if (gameObject.transform.position.x > startCube.transform.position.x)
            {
                if (gameObject.transform.position.x > startCube.transform.position.x + transform.localScale.x)
                {
                    gameObject.AddComponent<Rigidbody>();
                    return;
                }

                float fark = Mathf.Abs(startCube.transform.position.x - gameObject.transform.position.x);
                GameObject droppingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                droppingCube.transform.localScale = new Vector3(fark, transform.localScale.y, transform.localScale.z);
                droppingCube.transform.position = startCube.transform.position +
                                                  Vector3.right * (fark / 2 + startCube.transform.localScale.x / 2) +
                                                  Vector3.up * startCube.transform.lossyScale.y;

                droppingCube.AddComponent<Rigidbody>(); //.drag = 16; // TEST 
                droppingCube.GetComponent<BoxCollider>(); //.enabled = false; // TEST

                droppingCube.GetComponent<Renderer>().material.SetColor("_Color", color);

                Destroy(droppingCube, 1f);

                Vector3 remainingScale = gameObject.transform.localScale;
                remainingScale.x -= fark;
                transform.localScale = remainingScale;
                transform.position += Vector3.left * fark / 2;
            }

            if (gameObject.transform.position.x < startCube.transform.position.x)
            {
                if (gameObject.transform.position.x < startCube.transform.position.x - transform.localScale.x)
                {
                    gameObject.AddComponent<Rigidbody>();
                    return;
                }

                float fark = Mathf.Abs(startCube.transform.position.x - gameObject.transform.position.x);
                GameObject droppingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                droppingCube.transform.localScale = new Vector3(fark, transform.localScale.y, transform.localScale.z);
                droppingCube.transform.position = startCube.transform.position +
                                                  Vector3.left * (fark / 2 + startCube.transform.localScale.x / 2) +
                                                  Vector3.up * startCube.transform.lossyScale.y;

                droppingCube.AddComponent<Rigidbody>(); //.drag = 16; // TEST 
                droppingCube.GetComponent<BoxCollider>(); //.enabled = false; // TEST

                droppingCube.GetComponent<Renderer>().material.SetColor("_Color", color);

                Destroy(droppingCube, 3);

                Vector3 remainingScale = gameObject.transform.localScale;
                remainingScale.x -= fark;
                transform.localScale = remainingScale;

                transform.position += Vector3.right * fark / 2;
            }
        }
    }
}