using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController characterController { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public float movementSpeed { get; private set; }
    [field: SerializeField] public Transform mainCameraTransform { get; private set; }

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;

        Debug.Log("PlayerStateMachine Start!");
        SwitchState(new PlayerStateTest(this));
    }
}
