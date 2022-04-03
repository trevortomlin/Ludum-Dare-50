using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 10f;

    private float xInput;

    private bool grounded = false;

    private float boundXleft = -13.4f;
    private float boundXright = 13.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && grounded){
            rb2d.AddForce(new Vector2(0, 500));
        }

        xInput = Input.GetAxis("Horizontal") * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundXleft, boundXright),
                                         transform.position.y,
                                         0);

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = xInput;
        rb2d.velocity = velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Death(Clone)") { GameManager.Instance.Death(); }

        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
