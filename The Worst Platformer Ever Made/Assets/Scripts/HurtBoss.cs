using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoss : MonoBehaviour
{

    BossBehavior bossbehavior;
    // Start is called before the first frame update
    void Start()
    {
        bossbehavior = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehavior>();
    }

    // Update is called once per frame
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Boss")
            {

            Debug.Log("test");
            bossbehavior.TakeBossDamage();

            }
        }
   
}
