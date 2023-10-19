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
        //if Jumping
        //Jump();
    }
    public void Jump(float initialVelocity)
    {
        controller.SetState(controller.inAir);
    }
}
