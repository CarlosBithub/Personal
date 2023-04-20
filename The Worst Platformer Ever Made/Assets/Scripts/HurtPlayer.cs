using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    PlayerManager playermanager;
    // Start is called before the first frame update
    void Start()
    {
        playermanager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playermanager.TakeDamage();
            
        }
    }

}
