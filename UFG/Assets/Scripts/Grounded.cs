using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State
{
    protected override void OnEnter()
    {
        //Play Idle Animation
    }
    protected override void OnUpdate()
    {

    }

    public void Jump()
    {
        Debug.Log("Jumping!");
        controller.SetState(controller.inAir, Time.time);
    }
    public override void OnJump()
    {
        Debug.Log("Jump input!");
        Jump();

    }
}
