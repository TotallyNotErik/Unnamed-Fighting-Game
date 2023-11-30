using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jabbing : Attacking
{
    public Jabbing(int x, int y, int z)
    {
        hitStun = x;
        knockBack = y;
        moveFrames = z;
    }
    protected override void playAnimation(bool activate)
    {
        controller.anim.SetBool("Jab", activate);
    }
}
