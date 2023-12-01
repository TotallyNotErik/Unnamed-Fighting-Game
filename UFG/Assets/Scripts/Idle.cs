using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The idle class does nothing but play an animation, but allows for any action to be taken*/
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
    }

}
