using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class StateController : MonoBehaviour
{
    [Header("State Machine Information")]
    public GameObject opponent;
    public Idle idle;
    public InAir inAir;
    public Walking walking;
    public Running running;
    public HitTaken hitTaken;
    public HeavyHitTaken heavyHitTaken;

    [Header("Inputs")]
    public FrameInputs[] inputs = new FrameInputs[30];
    public int i = 0;
    private int inputOne;
    private int inputTwo;



    [Header("Character Stats")]
    public State currentState;
    public float jumpVelocity;
    public float walkSpeed;
    public float runSpeed;


    void Start()
    {
        idle = new Idle();
        inAir = new InAir(jumpVelocity);
        walking = new Walking(walkSpeed);
        hitTaken = new HitTaken();
        //running = new Running(runSpeed);

        SetState(idle);
    }
    public void Update ()
    {
        setInput(0, 0, 0);
        if (inputOne == inputTwo)
            inputTwo = 0;
        setInput(inputOne, inputTwo, 0);

        i++;
        if (i >= 30)
            softClearInputs();

        currentState.OnStateUpdate();
        OverriddenUpdate();
    }

    protected virtual void OverriddenUpdate ()
    {

    }

    /* This Section is the function used to change the current state.
     * The first function is the base SetState function.  If the state is already active, it will return.  
     * Otherwise, as long as the current state is not null, it will play the current state's exit function, then set the state to the new state, 
     * then play the new state's enter function
     *
     * The second function is an overloaded version, solely for handling mid-air state changes (ie. falling and punching at the same time.)
     * it does the exact same function, but also passes a time value into the onStateEnter function.
     */
    public void SetState(State state)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        Debug.Log("State Set!");
        currentState = state;
        currentState.OnStateEnter(this);
    }
    public void SetState(State state, float takeOffTime)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        currentState = state;
        currentState.OnStateEnter(takeOffTime, this);
    }

    /*This section is to read in inputs and transfer them into the input buffer
     * This is achieved through the Unity Input System Package Press interaction, which
     * calls the function once when the input is started, and again when the input
     * is ended.
     * 
     * This function will set a boolean to its opposite every time it is called, when the boolean becomes true, it sets 
     * the corresponding input.  
     * When the boolean becomes false, it will set the input to neutral.
     * 
     * For single button inputs, the boolean expressions are not necessary.
     */
    private bool right = false;
    private bool left = false;
    private bool down = false;
    private bool jump = false;

    void OnJump()
    {
        jump = !jump;
        if(jump)
        {
            if (inputTwo == 0)
                inputTwo = 1;
        }
        if (!jump)
            inputTwo = 0;

    }
    void OnLeft()
    {
        left = !left;
        if(left)
        {
            if (inputOne == 0)
                inputOne = 2;

        }
        if (!left)
            inputOne = 0;
    }
    void OnRight()
    {
        right = !right;
        if (right)
        {
            if (inputOne == 0)
                inputOne = 3;
        }
        if (!right)
                inputOne = 0;
    }


    void OnDown()
    {
        down = !down;
        if (down)
        {
            if (inputTwo == 0)
                inputTwo = 4;
        }
        if (!down)
            inputTwo = 0;

    }
    void OnPunch()
    {
        setInput(5);
    }
    void OnKick()
    {
        setInput(6);
    }
    void OnJab()
    {
        setInput(7);
    }

    /* softClearInputs() will shift all inputs down by one.*/
    void softClearInputs()
    {
        for (int j = 0; j < inputs.Length - 1; j++)
        {
            inputs[j].One = inputs[j + 1].One;
            inputs[j].Two = inputs[j + 1].Two;
            inputs[j].Three = inputs[j + 1].Three;
        }
        i = 29;
        setInput(0, 0, 0);
    }
    /* clearInputs() will set all inputs to 0, then reset the input frame to 0*/
    void clearInputs()
    {
        for (int j = 0; j < inputs.Length; j++)
        {
            inputs[j].One = 0;
            inputs[j].Two = 0;
        }
        i = 0;
    }
    void setInput(int x, int y, int z = 0)
    {
        inputs[i].One = (InputEnum)x;
        inputs[i].Two = (InputEnum)y;
        inputs[i].Three = (InputEnum)z;
        Debug.Log(inputs[i].One);
        Debug.Log(inputs[i].Two);
        return;
    }
    void setInput(int z)
    {
        inputs[i].Three = (InputEnum)z;
        Debug.Log(inputs[i].Three);
    }
    
}
