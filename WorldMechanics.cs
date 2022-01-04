using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMechanics : MonoBehaviour
{
    public Transform player;
    public GameObject mainCamera;
    public float speed = 25f;

    private Transform cameraPos;
    private float distance;
    private Rigidbody camRB;
    private int count = 0;
    public int numLevels = 1;
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        camRB = mainCamera.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //First Gather The position of the camera and set the distance
        cameraPos = mainCamera.GetComponent<Transform>();
        distance = Mathf.Abs(player.position.z - cameraPos.position.z);
        
        //Setting Camera Movement
        //First check that if the player has been moved to close to the camera, move the camera back
        //Second add force to the camera
        if (distance < 10f || player.position.z < cameraPos.position.z)
        {
            cameraPos.position = new Vector3(cameraPos.position.x, cameraPos.position.y, player.position.z - 10f);
        } else if (distance >= 30f) {
            //Debug.Log("You Lose");
            Application.Quit();
        } else {
            speed = 25f;
        }
        
        camRB.velocity = Vector3.back * speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (GameObject.FindGameObjectWithTag("NextLevel") == null) {
            GameObject currentLevel = GameObject.FindGameObjectWithTag("CurrentLevel");
            Instantiate(level, new Vector3(currentLevel.transform.position.x, currentLevel.transform.position.y, currentLevel.transform.position.z - 10f), Quaternion.identity);
            numLevels++;
        }
    }
}
