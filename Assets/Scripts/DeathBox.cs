using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public int speed = 3;

    public int speedIncrease = 1;

    public float speedTimer = 30f;

    private float elapsedTime = 0f;

    private bool moving = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) { return; }

        transform.Translate(Vector2.down * Time.deltaTime * speed);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > speedTimer)
        {
            speed += speedIncrease;
            elapsedTime = 0;

        }


    }

    public void SetMoving(bool s) {

        moving = s;
    
    }

}
