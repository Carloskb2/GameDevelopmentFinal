using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public AgentDataSO agentData;

    public Rigidbody2D rb2d;
    public PlayerInput agentInput;
    public AgentAnimation animationManager;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public ClimbingDetector climbingDetector;   

    public State currentState = null, previousState = null;
    public State IdleState;

    [Header("State Debugging:")]
    public String stateName = "";

    private void Awake()
    {
        agentInput = GetComponentInParent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimation>();  
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbingDetector = GetComponentInChildren<ClimbingDetector>();

        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeState(this);

        }
    }

    private void Start()
    {
        //adds HandleMovement to the OnMovement event action delegate, it will be called everytime we call OnMovement
        // and use its parameters MovementVector == Vector2 input
        
        agentInput.OnMovement += agentRenderer.FaceDirection;
        TransitionToState(IdleState);
        
    }
    internal void TransitionToState(State desiredState)
    {
        if (desiredState == null)
            return;
        if (currentState != null)
            currentState.Exit();

        previousState = currentState;
        currentState = desiredState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if(previousState == null || previousState.GetType() != currentState.GetType()) 
        {
            stateName = currentState.GetType().ToString();
        }
    }

    private void Update()
    {
        currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        groundDetector.CheckIsGrounded();   
        currentState.StateFixedUpdate();
    }
}
