using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Do Stuff
            PlayerManager manager = collision.GetComponent<PlayerManager>();
            if (manager)
            {
                //left off here period 1
                bool PickedUp = manager.PickupItem(gameObject);

                if (PickedUp)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
