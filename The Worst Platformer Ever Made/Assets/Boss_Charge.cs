using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Charge : StateMachineBehaviour
{
   
    //creates a place to store the players transform information.
    Transform player;
    //creates a place to store the rigidbody
    Rigidbody2D rb;

    public float distance;

    //create a place to store our bosses behavior
    BossBehavior bossBehaviour;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //sets the reference for our players location
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //set reference for my rigidbody
        rb = animator.GetComponent<Rigidbody2D>();

        //set and fill the infomation we are looking for
        bossBehaviour = animator.GetComponent<BossBehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehaviour.LookAtPlayer();
        //finds the player as target and locks the boss on the y axis
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        //send our boss to move towards its target 
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossBehaviour.speed * Time.deltaTime);

        //tell our boss to move its position
        rb.MovePosition(newPos);

        distance = Vector2.Distance(player.position, rb.position);
        //Phase 1 
        if (distance < bossBehaviour.attackRange && !bossBehaviour.phase2&& !bossBehaviour.phase3 && !bossBehaviour.isdead)
        {
            animator.SetTrigger("MeleeAttack");
        }
        //phase 2
        else if (distance< bossBehaviour.attackRange && bossBehaviour.phase2 && !bossBehaviour.phase3 && !bossBehaviour.isdead)
        {
            animator.SetTrigger("Phase2Attack");
        }
        //phase 3
        else if (distance < bossBehaviour.attackRange && !bossBehaviour.phase2 && bossBehaviour.phase3 && !bossBehaviour.isdead)
        {
            animator.SetTrigger("Phase3Attack");
        }
        //Its dead!
        else if (bossBehaviour.isdead)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
