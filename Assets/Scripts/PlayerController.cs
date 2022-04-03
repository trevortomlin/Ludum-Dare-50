using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 10f;

    public float jumpForce = 250f;

    public LayerMask groundLayer;

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
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        xInput = Input.GetAxis("Horizontal") * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundXleft, boundXright),
                                         transform.position.y,
                                         0);

        Debug.DrawRay(transform.position, Vector2.down, Color.green);

    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = xInput;
        rb2d.velocity = velocity;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        if (hit.collider != null)
        {
            grounded = true;
        }

        else
        {

            grounded = false;

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Death(Clone)") { GameManager.Instance.Death(); }

    }

}
