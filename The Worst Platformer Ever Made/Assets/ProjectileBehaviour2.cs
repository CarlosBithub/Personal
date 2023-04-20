using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour2 : MonoBehaviour
{
    Transform player;
    Transform boss;
    Vector2 direction;
    Rigidbody2D rb;
    public float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        if (boss.position.x >= player.position.x)
        {
            direction = new Vector2(-1, 1.5f);
        }
        else
        {
            direction = new Vector2(1, 1.5f);
        }
    }


    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "")
            Destroy(gameObject);
    }
}
