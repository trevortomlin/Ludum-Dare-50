using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 10f;

    public CameraShake cameraShake;

    public ParticleSystem fallingParticle;
    public ParticleSystem groundHitParticle;
    public ParticleSystem deathParticle;

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

        cameraShake = Camera.main.GetComponent<CameraShake>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && grounded){
            AudioManager.Instance.Play("Jump");
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        xInput = Input.GetAxis("Horizontal") * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundXleft, boundXright),
                                         transform.position.y,
                                         0);

        if (rb2d.velocity.y < -7) {

            Vector3 particlePos = transform.position;
            particlePos.z = -2;
            Instantiate(fallingParticle, particlePos, Quaternion.identity);

        }

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

        if (collision.collider.name.Equals("Death(Clone)")) {

            int highScore = Mathf.Max(PlayerPrefs.GetInt("HighScore"), (int) transform.position.y * -1);

            PlayerPrefs.SetInt("HighScore", highScore);

            Vector3 particlePos = transform.position;
            particlePos.z = -2;

            AudioManager.Instance.Play("Hit_Hurt");
            Instantiate(deathParticle, particlePos, Quaternion.identity);

            StartCoroutine(cameraShake.Shake(.2f, .4f));

            GameManager.Instance.Death(); 
        
        }

        else if (collision.collider.name.Equals("Platform(Clone)"))
        {

            float impactVelocity = collision.relativeVelocity.y;

            if (impactVelocity > 15f) {

                Vector3 particlePos = collision.contacts[0].point;
                particlePos.z = -1;

                AudioManager.Instance.Play("HitGround");

                Instantiate(groundHitParticle, particlePos, Quaternion.identity);

                StartCoroutine(cameraShake.Shake(.15f, .4f));

            }


        }

    }

}
