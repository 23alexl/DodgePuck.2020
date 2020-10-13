using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{
    public int[] direction = { 0, 1, 2, 3 };
    public int moveDirection;
    public float puckSpeed = 5.0f; 
    public float xRange = 9.0f;
    public float yRange = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = direction[Random.Range(0,4)];
        Debug.Log(moveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDirection == 0)
        {
            //move up
            transform.Translate(transform.up * puckSpeed * Time.deltaTime);
        }
        if (moveDirection == 1)
        {
            //move right
            transform.Translate(transform.right * puckSpeed * Time.deltaTime);
        }
        if (moveDirection == 2)
        {
            //move down
            transform.Translate(transform.up * -puckSpeed * Time.deltaTime);
        }
        if (moveDirection == 3)
        {
            //move left
            transform.Translate(transform.right * -puckSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()

    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))

        {
            puckSpeed = -puckSpeed;
            //Debug.Log("Hit Wall");
        }
    }
    



}


