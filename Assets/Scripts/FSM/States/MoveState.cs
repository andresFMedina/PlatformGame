using UnityEngine;

public class MoveState : PlayerBaseState
{
    public override void Enter(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.MOVING, true);
    }

    public override void Exit(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.MOVING, false);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerController player)
    {
        player.horizontalInput = Input.GetAxisRaw("Horizontal");
        bool grounded = Physics2D.Raycast(player.transform.position, Vector3.down, 0.125f);
        Debug.Log("Move To Idle");
        player.TransitionToState(player.IdleState);
        player.playerRigidBody.velocity = new Vector2(player.horizontalInput * player.characterStats.GetCurrentMoveSpeed(), player.playerRigidBody.velocity.y);
        Debug.Log(player.playerRigidBody.velocity);
        if (player.horizontalInput != 0)
        {

            Debug.Log("Move To Idle");
            player.TransitionToState(player.IdleState);
        }

        if (player.horizontalInput < 0) player.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (player.horizontalInput > 0) player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Move To Jump");            
            player.TransitionToState(player.JumpState);
        }
    }
}
