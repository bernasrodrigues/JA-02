using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : CommandManager.ICommand
{
    float verticalDirection;
    float horizontalDirection;
    float moveSpeed;

    Rigidbody r;
    float maxVelocityChange;




    public MoveCommand(float verticalDirection , float horizontalDirection , PlayerMovement playerMovement )
    {


        //get used values that are to be used
        r = playerMovement.GetRigidBody();
        maxVelocityChange = playerMovement.maxVelocityChange;
        moveSpeed = playerMovement.speed;                       // CHANGE THIS TO GET VALUES DIRECTLY FROM THE PLAYER

        this.verticalDirection = verticalDirection * (playerMovement.cameraDistance >= 0 ? -1 : 1);
        this.horizontalDirection = horizontalDirection * (playerMovement.cameraDistance >= 0 ? 1 : -1);

    }





    public void Execute()
    {
        Vector3 targetVelocity = new Vector3(verticalDirection, 0, horizontalDirection);
        targetVelocity *= moveSpeed;

        Vector3 velocity = r.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;


        r.AddForce(velocityChange, ForceMode.VelocityChange);
    }


    public void Undo()
    {
        
    }
}
