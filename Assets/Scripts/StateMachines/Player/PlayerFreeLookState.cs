using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed"); // string값을 직접 넣기보다 정수로 변환해서 더 빠른 계산 가능

    private const float AnimatorDampTime = 0.1f;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
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

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            //stateMachine.animator.SetFloat("FreeLockSpeed", 0, 0.1f, deltaTime);
            stateMachine.animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }


        stateMachine.animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movement, deltaTime);

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
    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(stateMachine.transform.rotation, Quaternion.LookRotation(movement), deltaTime * stateMachine.RotationDamping);
        
    }
}
