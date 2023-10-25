using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class StateController : MonoBehaviour
{
    public GameObject opponent;
    public Idle idle;
    public InAir inAir;
    public Walking walking;
    public Running running;
    public HitTaken hitTaken;
    public HeavyHitTaken heavyHitTaken;
    public FrameInputs[] inputs = new FrameInputs[30];
    public int i = 0;
    private int inputOne;
    private int inputTwo;
    private bool right = false;
    private bool left = false;
    private bool down = false;

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
        setInput(inputOne, inputTwo);

        i++;
        if (i >= 30)
            softClearInputs();

        currentState.OnStateUpdate();
        OverriddenUpdate();
    }

    protected virtual void OverriddenUpdate ()
    {

    }
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

    void OnJump()
    {
        setInput(1);

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
