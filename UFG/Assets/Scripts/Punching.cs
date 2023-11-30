using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : Attacking
{
    public Punching(int x, int y, int z)
    {
        hitStun = x;
        knockBack = y;
        moveFrames = z;
    }
    protected override void playAnimation(bool activate)
    {
        controller.anim.SetBool("Punch", activate);
    }
}