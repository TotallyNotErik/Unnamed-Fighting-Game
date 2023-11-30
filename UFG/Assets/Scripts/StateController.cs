using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
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
    public Walking running;
    public HitTaken hitTaken;
    public HeavyHitTaken heavyHitTaken;
    public WalkingBackwards walkingBackwards;
    public Dashing dashing;
    public AirDashing airDashing;
    public Punching punching;
    public Kicking kicking;
    public Jabbing jabbing;
    public Animator anim;
    public Blocking blocking;
    [Header("Inputs")]
    public FrameInputs[] inputs = new FrameInputs[30];
    public int i = 0;
    private int inputOne;
    private int inputTwo;
    private int inputThree;



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
        walkingBackwards = new WalkingBackwards(walkSpeed/2);
        dashing = new Dashing();
        airDashing = new AirDashing();
        running = new Walking(runSpeed);
        punching = new Punching(8, 5, 8);
        kicking = new Kicking(12, 10, 12);
        jabbing = new Jabbing(6, 3, 6);
        blocking = new Blocking();

        SetState(idle);
    }
    public void Update ()
    {
        if (!GameManager.instance.gameStarted)
        { return; }
        if (this.transform.position.x - opponent.transform.position.x > 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        //setInput(0, 0, 0);
        setInput(inputOne, inputTwo, inputThree);
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
     * The second function is an overloaded version, but allows for a value to be passed through.
     * it does the exact same function, but also passes a time value into the onStateEnter function.
     */
    public void SetState(State state)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        currentState = state;
        currentState.OnStateEnter(this);
    }
    public void SetState(State state, float valueToPass)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        currentState = state;
        currentState.OnStateEnter(valueToPass, this);
    }
    public void SetState(State state, float valueToPassOne, float valueToPassTwo)
    {
        if (state == currentState) return;
        else if (currentState != null) currentState.OnStateExit();

        currentState = state;
        currentState.OnStateEnter(valueToPassOne,valueToPassTwo, this);
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
            {
                inputOne = 2;
            }

        }
        if (!left)
        {
            inputOne = 0;
        }
    }
    void OnRight()
    {
        right = !right;
        if (right)
        {
            if (inputOne == 0)
            {
                inputOne = 3;
            }
        }
        if (!right)
        {
            inputOne = 0;
        }

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
    void OnDash()
    {
        setInput(5);
    }
    void OnPunch()
    {
        setInput(6);
    }
    void OnKick()
    {
        setInput(7);
    }
    void OnJab()
    {
        setInput(8);
    }

    /* softClearInputs() will shift all inputs down by one.*/
    void softClearInputs()
    {
        for (int j = 0; j < inputs.Length - 1; j++)
        {
            inputs[j].One = inputs[j + 1].One;
            inputs[j].Two = inputs[j + 1].Two;
            inputs[j].Three = inputs[j + 1].Three;
            inputs[j].Four = inputs[j + 1].Four;
        }
        i = 29;
    }
    /* clearInputs() will set all inputs to 0, then reset the input frame to 0*/
    void clearInputs()
    {
        for (int j = 0; j < inputs.Length; j++)
        {
            inputs[j].One = 0;
            inputs[j].Two = 0;
            inputs[j].Three = 0;
            inputs[j].Four = 0;
        }
        i = 0;
    }
    void setInput(int x, int y, int z)
    {
        inputs[i].One = (InputEnum)x;
        inputs[i].Two = (InputEnum)y;
        inputs[i].Three = (InputEnum)z;
        inputs[i].Four = (InputEnum)0;
        if (x != 0)
        {
            if(this.transform.position.x <= opponent.transform.position.x)
            {
                if (x == 2)
                    inputs[i].Four = (InputEnum)10;
                else if (x == 3)
                    inputs[i].Four = (InputEnum)9;
            }
            else if (this.transform.position.x > opponent.transform.position.x)
            {
                if (x == 2)
                    inputs[i].Four = (InputEnum)9;
                else if (x == 3)
                    inputs[i].Four = (InputEnum)10;
            }

        }
        inputThree = 0;

        //Debug.Log(inputs[i].One);
        //Debug.Log(inputs[i].Two);
        //Debug.Log(inputs[i].Three);
        //Debug.Log(inputs[i].Four);
        return;
    }
    void setInput(int z)
    {
        inputThree = z;
    }
    
}
