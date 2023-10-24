using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    protected override void OnEnter()
    {
        cancel = true;
    }

    protected override void OnUpdate()
    {
        //Down
            //Crouch

        //Forward
            //Walk

        //Back
            //WalkBackwards?
    }

}
