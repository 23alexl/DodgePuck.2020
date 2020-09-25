﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int score = 7;
    public int hiscore = 10;
    private int temp = 70;
    public float location;
    public float loc2 = 1.5f; 
    public float speed = 10.0f;
    public float xRange = 9.0f;
    public float yRange = 6.0f;
    public GameObject Puck;
    public GameObject Blocky;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello, World");
        score += 2;
        Debug.Log(score + hiscore + temp);
        Debug.Log("location: + 0.5f");
        SpawnPuck();
    }

    void SpawnPuck()
    {
        Debug.Log(Random.Range(1.0f,10.0f));
        Instantiate(Puck, new Vector2(Random.Range(-9.0f, 9.0f), Random.Range(-6f, 6f)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPuck();

        float moveHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
           Debug.Log(Input.GetAxis("Horizontal"));
           transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void LateUpdate()
    {


        //Keep Player within xRange (Left and Right sides)
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
  
            if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }


}
