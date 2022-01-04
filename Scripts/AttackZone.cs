using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public Transform player;
    public Vector3 playerTransform;
    public Quaternion playerRotation;
    private bool right = true;

    void Update()
    {
        transform.SetPositionAndRotation(player.position, playerRotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Entered");
        }
    }
}
