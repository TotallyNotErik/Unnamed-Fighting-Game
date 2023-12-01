using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Walking : Grounded
{
    protected float walkSpeed;


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
    protected override void OnExit()
    {
        controller.anim.SetBool("Walking", false);
    }
    public Walking(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }
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
    protected override void OnGroundChildUpdate()
    {
        if(Mathf.Abs(controller.transform.position.x + walkSpeed*Time.deltaTime) > 10) { return; }
        else
            controller.transform.position += new Vector3(walkSpeed * Time.deltaTime,0,0);
    }
}
