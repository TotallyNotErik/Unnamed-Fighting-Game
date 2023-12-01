using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Walking : Grounded
{
    protected float walkSpeed;

    /*Overrides the base State class OnEnter to start a walking animation, and set a direction.*/
    protected override void OnEnter(float movement)
    {
        controller.anim.SetBool("Walking", true);
    moveOver = true;
        cancel = true;
        if (movement < 0)
            walkSpeed = -Mathf.Abs(walkSpeed);
        else if (movement > 0)
            walkSpeed = Mathf.Abs(walkSpeed);
    }
    /*turns off walking Animation*/
    protected override void OnExit()
    {
        controller.anim.SetBool("Walking", false);
    }
    /*Constructor to set the walkspeed into the state*/
    public Walking(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }
    /*Overrides the Grounded State's Jump Function to jump forward or backwards rather than just straight up*/
    protected override void Jump()
    {
        controller.SetState(controller.inAir, controller.jumpVelocity, walkSpeed);
    }
    public override void OnLeft() 
    {
        int direction = -1;
        if (moveOver || cancel)
        {
            if (forwardBack.z == 9)
            {
                controller.SetState(this, direction);
            }
            else if (forwardBack.z == 10)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }
    }
    public override void OnRight()
    {
        int direction = 1;
        if (moveOver || cancel)
        {
            if (forwardBack.z == 9)
            {
                controller.SetState(this, direction);
            }
            else if (forwardBack.z == 10)
            {
                controller.SetState(controller.walkingBackwards, direction);
            }
        }

    }

    /*Overrides the update function to move depending on th direction and speed set in OnEnter*/
    protected override void OnGroundChildUpdate()
    {
        if(Mathf.Abs(controller.transform.position.x + walkSpeed*Time.deltaTime) > 10) { return; }
        else
            controller.transform.position += new Vector3(walkSpeed * Time.deltaTime,0,0);
    }
}
