using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateTest : PlayerBaseState
{
    public PlayerStateTest(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        stateMachine.characterController.Move(movement * stateMachine.movementSpeed * deltaTime);

        if( stateMachine.InputReader.MovementValue == Vector2.zero )
        {
            stateMachine.animator.SetFloat("FreeLockSpeed", 0, 0.1f, deltaTime);
            return; 
        }


        stateMachine.animator.SetFloat("FreeLockSpeed", 1, 0.1f, deltaTime);
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        
    }

    public override void Exit()
    {

    }

    Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.mainCameraTransform.forward;
        Vector3 right = stateMachine.mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }
}
