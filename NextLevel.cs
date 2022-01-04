using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject player;
    public Transform playerPos;
    public GameObject openDoor;
    public GameObject closedDoor;
    private GameObject[] enemies;
    private int numEnemies;
    private WorldMechanics world;
    public GameObject nextLevel;
    public GameObject currentLevel;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = countEnemies(enemies);
    }

    private void Update() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = countEnemies(enemies);
        playerPos = player.transform;
        if (numEnemies == 0) {
            openDoor.GetComponent<SpriteRenderer>().enabled = true;
            openDoor.GetComponent<BoxCollider2D>().enabled = true;
            closedDoor.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        nextLevel = GameObject.FindGameObjectWithTag("NextLevel");
        currentLevel = GameObject.FindGameObjectWithTag("CurrentLevel");
        Debug.Log("Player is infront of door");
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Player pressed e");
            nextLevel.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
            player.transform.position = new Vector3(nextLevel.transform.position.x + 3f, nextLevel.transform.position.y - 4.5f, nextLevel.transform.position.z);
            Destroy(currentLevel);
        }
    }

    public int countEnemies(GameObject[] enemies)
    {
        int count = 0;
        foreach (GameObject element in enemies)
        {
            if (element.activeInHierarchy == true)
            {
                count++;
            }
        }
        return count;
    }
}
