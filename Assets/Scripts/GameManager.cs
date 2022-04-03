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

    public GameObject playerPrefab;
    public GameObject deathPrefab;

    private Transform playerT;

    private GameObject playerInstance;
    private GameObject deathInstance;

    private float boundXleft = -13.4f;
    private float boundXright = 13.4f;

    public GameObject deathPanel;

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

    public void Death() {

        playerInstance.GetComponent<PlayerController>().rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        deathInstance.GetComponent<DeathBox>().SetMoving(false);

        deathPanel.SetActive(true);
    
    }

    public void Restart()
    {

        deathPanel.SetActive(false);

        Destroy(playerInstance);
        Destroy(deathInstance);

        Camera.main.transform.position = new Vector3(0, 0, -10);

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }

        numPlatsOnScreen = 0;

        Start();

    }

    void Start()
    {

        playerInstance = Instantiate(playerPrefab, new Vector2(0,0), Quaternion.identity);
        deathInstance = Instantiate(deathPrefab, new Vector2(0, 15), Quaternion.identity);

        Camera cam = Camera.main;

        Vector3 platPos = new Vector3();

        for (int i = 0; i < platformCount; i++) {

            platPos.x = cam.transform.position.x + Random.Range(boundXleft, boundXright);
            platPos.y = cam.transform.position.y - 18 - Random.Range(0, 18f);

            GameObject platformGO = Instantiate(platformPrefab, platPos, Quaternion.identity);

            numPlatsOnScreen++;

        }

    }

    // Update is called once per frame
    void Update()
    {

        depthText.text = -1 * (int) playerInstance.transform.position.y + "m";

        Camera cam = Camera.main;

        if (numPlatsOnScreen < platformCount) { 

            Vector3 platPos = new Vector3();

            for (int i = 0; i < (platformCount - numPlatsOnScreen); i++)
            {

                platPos.x = cam.transform.position.x + Random.Range(boundXleft, boundXright);
                platPos.y = cam.transform.position.y - 9 - Random.Range(0, 18f);

                GameObject platformGO = Instantiate(platformPrefab, platPos, Quaternion.identity);

                numPlatsOnScreen++;

            }


        }


    }
}
