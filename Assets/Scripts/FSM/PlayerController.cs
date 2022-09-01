using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimatorController;
    public CharacterStats characterStats;
    public Rigidbody2D playerRigidBody;

    public float horizontalInput { get; set; }

    private PlayerBaseState currentState;

    public readonly IdleState IdleState = new();
    public readonly MoveState MoveState = new();
    public readonly DeathState DeathState = new();
    public readonly JumpState JumpState = new();

    private void Awake()
    {
        playerAnimatorController = GetComponent<Animator>();
        characterStats = GetComponent<CharacterStats>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        TransitionToState(IdleState);       
    }


    public void TransitionToState(PlayerBaseState state)
    {
        if (currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = state;        
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
        {
            
        }
    }
}


