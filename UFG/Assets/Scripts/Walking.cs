using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Walking : Grounded
{
    private float walkSpeed;

    public Walking(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }

    protected override void OnUpdate()
    {
        controller.transform.position += new Vector3(walkSpeed * Time.deltaTime,0,0);
    }
}
