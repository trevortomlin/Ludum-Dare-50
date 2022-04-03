using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    public int speed = 1;

    public int speedIncrease = 1;

    public float speedTimer = 30f;

    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > speedTimer)
        {
            speed += speedIncrease;
            elapsedTime = 0;

        }


    }
}
