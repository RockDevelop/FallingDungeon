using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomizer : MonoBehaviour
{
    public GameObject[] setup = new GameObject[3];

    // Awake is called when the object is set to active
    void Awake()
    {
        setup[Random.Range(0,2)].SetActive(true);
    }
}
