using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateController
{
    /*Overrides the Start Function to turn this controller into a mindless bot*/
    protected override void OverrideStart()
    {
        GameManager.instance.makeBot(this);
    }
}
