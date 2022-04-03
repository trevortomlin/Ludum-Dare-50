using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform playerT;

    public Transform underGroundSprite;

    public void Start()
    {
        
        //Debug.Log(playerT.position);

    }

    private void LateUpdate()
    {
        if (playerT == null) {

            playerT = GameObject.FindGameObjectsWithTag("Player")[0].transform;
            return;

        }

        // Move camera down if player is above it
        if (playerT.position.y < transform.position.y) {

            Vector3 pos = new Vector3(transform.position.x, playerT.position.y, transform.position.z);
            transform.position = pos;

            // Move underground sprite with player
            underGroundSprite.position = new Vector3(transform.position.x, playerT.position.y, 0);

        }
    }

}
