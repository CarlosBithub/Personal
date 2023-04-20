using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    //Reference to our points.
    public List<Transform> points;
    //the next int value for the next indexed in our list.
    public int nextID;
    //will be used to change the nextId #
    private int idchangeValue = 1;
    //used to set the speed for our enemy movement.
    public float speed;
    //Reference to our player.
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //check if the player is withn distance of the enemy.
        if (Vector2.Distance(transform.position, player.position) < 6f)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x , transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            Patrol();
        }  
        
    }

    private void Patrol()
    {
        //set a goalpoint using the next point in transform list
        Transform goalPoint = points[nextID];
        //flip our enemys transform to look at points direction
        if(goalPoint.transform.position.x> transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        //move the enemy towards the goal point 
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //check the distances between the enemy and the goalpoint to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position)<1f)
            {
            //check if we are at the end of the line to make this change -1 
            if (nextID == points.Count - 1)
            {
                idchangeValue = -1;
            }
            //check if we are at the start of the line,make the change to +1
            if (nextID == 0)
            {
                idchangeValue = 1;
            }
            //apply the change on the next id
            nextID += idchangeValue;
            }
    }

}
