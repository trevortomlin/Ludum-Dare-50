using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    // https://stackoverflow.com/questions/54299107/spawning-and-destroying-random-platforms-in-unity
    private SpriteRenderer sprite;
    private float topOfScreen;

    //public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Relocate()
    {

        /*Vector3 newPos = new Vector3();

        newPos.x = transform.position.x + Random.Range(-2f, 2f);
        newPos.y = transform.position.y + Random.Range(-2f, 2f);

        transform.position = newPos;*/

        GameManager.Instance.numPlatsOnScreen--;
        Destroy(gameObject);

    }


    // Update is called once per frame  
    void Update()
    {
        var cam = Camera.main;
        var screen = new Vector2(Screen.width, Screen.height);
        var camWorldPos = cam.ScreenToWorldPoint(screen);
        topOfScreen = camWorldPos.y + cam.orthographicSize / 2;

        var height = sprite.bounds.size.y;
        var topOfPlatform = transform.position.y + height / 2;

        //Debug.Log(topOfPlatform + " " + topOfScreen);

        if (topOfPlatform > topOfScreen)
        {
            //Debug.Log("Deleted.");
            GameManager.Instance.numPlatsOnScreen--;
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Platform(Clone)")
        {
            //Debug.Log("Collision");
            Relocate();
        }

    }

    /*private void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log("Collision");
    }*/
}
