using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager Instance { get; private set; }

    public GameObject platformPrefab;

    public int platformCount = 1;

    public int numPlatsOnScreen = 0;

    public TextMeshProUGUI depthText;

    public GameObject Player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Start()
    {

        Camera cam = Camera.main;

        Vector3 platPos = new Vector3();

        for (int i = 0; i < platformCount; i++) {

            platPos.x = cam.transform.position.x + Random.Range(-18f, 18f);
            platPos.y = cam.transform.position.y - 9 - Random.Range(0, 18f);

            GameObject platformGO = Instantiate(platformPrefab, platPos, Quaternion.identity);

            numPlatsOnScreen++;

        }

    }

    // Update is called once per frame
    void Update()
    {

        depthText.text = -1 * (int)Player.transform.position.y + "m";

        Camera cam = Camera.main;

        if (numPlatsOnScreen < platformCount) { 

            Vector3 platPos = new Vector3();

            for (int i = 0; i < (platformCount - numPlatsOnScreen); i++)
            {

                platPos.x = cam.transform.position.x + Random.Range(-18f, 18f);
                platPos.y = cam.transform.position.y - 18 - Random.Range(0, 18f);
                
                Instantiate(platformPrefab, platPos, Quaternion.identity);
                numPlatsOnScreen++;

            }


        }


    }
}
