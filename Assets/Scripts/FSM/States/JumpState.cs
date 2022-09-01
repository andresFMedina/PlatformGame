using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerBaseState
{
    public override void Enter(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.JUMPING, true);
    }

    public override void Exit(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.JUMPING, false);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerController player)
    {
        player.playerRigidBody.AddForce(Vector2.up * player.characterStats.GetCurrentJumpForce());
        bool grounded = Physics2D.Raycast(player.transform.position, Vector3.down, 0.125f);
        Debug.Log($"Grounded {grounded}");
        if (grounded)
        {
            Debug.Log("Jump To Idle");            
            player.TransitionToState(player.IdleState);
            return;
        }

        
        
    }
}
