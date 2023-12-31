using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAir : State
{
    private float InitialVelocity;
    private float takeoffTime;
    float lastPosition;
    private int fastFall = 1;
    private float horizontalVelocity = 0;
    public InAir(float InitialVelocity = 10)
    {
        this.InitialVelocity = InitialVelocity;
    }
    /*OnEnter will set initial velocitie for the OnUpdate function to perform physics calculations*/
    protected override void OnEnter(float valueToPass, float valueToPassTwo = 0)
    {
        controller.anim.SetBool("Jump",true);
        this.InitialVelocity = valueToPass;
        this.takeoffTime = Time.time;
        horizontalVelocity = valueToPassTwo;
        fastFall = 1;
        cancel = true;
    }
    /*OnUpdate will move the character up and down according to regular physics, and allows for a fastfall input at the peak of the jump*/
    protected override void OnUpdate()
    {

        lastPosition = controller.transform.position.y;
        if (Mathf.Abs(controller.transform.position.x + horizontalVelocity * Time.deltaTime) < 10)
            controller.transform.position += new Vector3(horizontalVelocity * Time.deltaTime, (InitialVelocity + -32 * (Time.time - takeoffTime)) * (Time.deltaTime) * fastFall, 0); 
        else
            controller.transform.position += new Vector3(0, (InitialVelocity + -32 * (Time.time - takeoffTime)) * (Time.deltaTime) * fastFall, 0);
        if (controller.transform.position.y <= 0 && takeoffTime < Time.time - 0.1)
        {
            controller.anim.SetBool("Jump", false);
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
    /*The base class Input Functions must be overrided to do nothing so no states can accidentally be changed mid-air*/
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
    /*Players can still dash mid-air*/
    public override void OnDash()
    {

        if (cancel && AirDashing.airDashes > 0)
            controller.SetState(controller.dashing);
    }
}
