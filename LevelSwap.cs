using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwap : MonoBehaviour
{
    public GameObject realLevel;
    public GameObject parent;
    public GameObject phantom;
    public GameObject level;
    private WorldMechanics world;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Player has entered area and realLevel has been activated");
            realLevel.SetActive(true);
            parent.tag = "CurrentLevel";
            world.numLevels += 1;
            Destroy(phantom);
        }
    }
}
