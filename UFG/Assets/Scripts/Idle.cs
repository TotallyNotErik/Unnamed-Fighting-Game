using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    protected override void OnEnter()
    {
        AirDashing.airDashes = 2;
        cancel = true;
        moveOver = true;
        controller.anim.SetTrigger("Idle");
    }

    protected override void OnGroundChildUpdate()
    {
        //Down
            //Crouch

        //Forward
            //Walk

        //Back
            //WalkBackwards?
    }

}
