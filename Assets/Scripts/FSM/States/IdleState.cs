using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void Enter(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.IDLE, true);
    }

    public override void Exit(PlayerController player)
    {
        player.playerAnimatorController.SetBool(PlayerStates.IDLE, false);
    }

    public override void OnCollisionEnter(PlayerController player)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(PlayerController player)
    {
        player.horizontalInput = Input.GetAxisRaw("Horizontal");
        bool grounded = Physics2D.Raycast(player.transform.position, Vector3.down, 0.125f);

        if (player.horizontalInput != 0.0f && grounded)
        {
            Debug.Log("Idle To Move");            
            player.TransitionToState(player.MoveState);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Idle To Jump");            
            player.TransitionToState(player.JumpState);
        }

        Debug.DrawRay(player.transform.position, Vector3.down * 0.125f, Color.red);
    }
}
