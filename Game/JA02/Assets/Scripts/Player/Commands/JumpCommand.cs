using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : CommandManager.ICommand
{
    Rigidbody r;
    float jumpHeight;
    float gravity;



    public JumpCommand(PlayerMovement playerMovement)
    {
        //get used values that are to be used
        r = playerMovement.GetRigidBody();
        jumpHeight = playerMovement.jumpHeight;                       // CHANGE THIS TO GET VALUES DIRECTLY FROM THE PLAYER
        gravity = playerMovement.gravity;
    }





    public void Execute()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        float jump = Mathf.Sqrt(2 * jumpHeight * gravity);              // HARDCODED GRAVITY



       r.velocity = new Vector3(r.velocity.x, jump, r.velocity.z);



    }


    public void Undo()
    {
        
    }
}
