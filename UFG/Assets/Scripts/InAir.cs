using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : State
{
    private float InitialVelocity;
    private float takeoffTime;
    float lastPosition;

    public InAir(float InitialVelocity = 10)
    {
        this.InitialVelocity = InitialVelocity;
    }

    protected override void OnEnter()
    {
        takeoffTime = Time.time;
    }
    protected override void OnUpdate()
    {
        lastPosition = controller.transform.position.y;
        controller.transform.position.y = InitialVelocity * (Time.time - takeoffTime) + (-32 * (Time.time - takeoffTime) * (Time.time - takeoffTime)) / 2;
        if (controller.transform.position.y == 0)
        {
            controller.SetState(controller.idle);
        }
        if (controller.transform.position.y - lastPosition > .5)
        {
            //Jumping Animation
        }

        else if (controller.transform.position.y - lastPosition < -.5)
        {
            //Falling Animation
        }

        else
        {
            //check for down input for fast fall
        }
    }
    
}
