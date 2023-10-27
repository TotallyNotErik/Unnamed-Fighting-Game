using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : State
{
    private float InitialVelocity;
    private float takeoffTime;
    float lastPosition;
    private int fastFall = 1;

    public InAir(float InitialVelocity = 10)
    {
        this.InitialVelocity = InitialVelocity;
    }

    protected override void OnEnter(float valueToPass)
    {
        this.InitialVelocity = valueToPass;
        this.takeoffTime = Time.time;
        fastFall = 1;
        cancel = true;
    }
    protected override void OnUpdate()
    {

        lastPosition = controller.transform.position.y;
        controller.transform.position += new Vector3(0, (InitialVelocity + -32 * (Time.time - takeoffTime)) * (Time.deltaTime) * fastFall, 0); ;
        if (controller.transform.position.y <= 0 && takeoffTime < Time.time - 0.1)
        {
            controller.transform.position = new Vector3(controller.transform.position.x,0, controller.transform.position.z);
            controller.SetState(controller.idle);
        }
        if (controller.transform.position.y - lastPosition > .1)
        {
            //Jumping Animation
        }

        else if (controller.transform.position.y - lastPosition < -.1)
        {
            //Falling Animation
        }

        else
        {
            if (upwardInput.z == 4 || upwardInput.y == 4 ||upwardInput.z == 4)
            {

                fastFall = 2;
                Debug.Log("Fast Falling");
            }

        }
    }

    public override void OnPunch()
    {
        if (cancel) { }
    }
    public override void OnLeft()
    {
        if (cancel) { }
    }
    public override void OnRight()
    {
        if (cancel) { }
    }
    public override void OnDown()
    {
        if (cancel) { }
    }
    public override void OnKick()
    {
        if (cancel) { }
    }
    public override void OnJab()
    {
        if (cancel) { }
    }
    public override void OnDash()
    {
        Debug.Log(AirDashing.airDashes);
        if (cancel && AirDashing.airDashes > 0)
            controller.SetState(controller.dashing);
    }
}
