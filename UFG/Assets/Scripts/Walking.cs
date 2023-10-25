using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Walking : Grounded
{
    protected float walkSpeed;


    protected override void OnEnter(float movement)
    {
        cancel = true;
        if (movement < 0)
            walkSpeed = -Mathf.Abs(walkSpeed);
        else if (movement > 0)
            walkSpeed = Mathf.Abs(walkSpeed);
    }
    public Walking(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }

    protected override void OnGroundChildUpdate()
    {
        controller.transform.position += new Vector3(walkSpeed * Time.deltaTime,0,0);
    }
}
