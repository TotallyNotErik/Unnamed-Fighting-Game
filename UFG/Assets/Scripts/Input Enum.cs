using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputEnum
{
    None,
    Jump,
    Left,
    Right,
    Down,
    Punch,
    Kick,
    Jab,
};

/*This Struct is the basis for the input buffer
 * One is for movement inputs, right and left
 * Two is for upwards inputs, Jump and down
 * Three is for attack inputs, Punch, Jab. Kick, and Dash
*/
public struct FrameInputs
{
    public InputEnum One; 
    public InputEnum Two;
    public InputEnum Three;
};

