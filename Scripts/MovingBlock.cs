using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float speed = 200f;
    Rigidbody2D rb;
    Vector3 velocity;
    public float min = -20f;
    public float max = 20f;
    public WorldMechanics world;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(20 * speed * Time.deltaTime, 20 * speed * Time.deltaTime));
        rb.velocity = new Vector2(Random.Range(min, max) * speed, Random.Range(min, max) * speed);
        //Debug.Log("Starting Velocity = " + rb.velocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rb.velocity;
        //Debug.Log("Velocity = " + velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var force = velocity.magnitude;
        var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(force, 0f);
        if (collision.gameObject.tag == "AttackZone")
        {
            gameObject.SetActive(false);
        }
    }
}
