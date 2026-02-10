using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    // 현재 실행 중인 상태
    private State currentState;

    // 상태 전환 메서드
    public void SwitchState(State newState)
    {
        currentState?.Exit(); // 현재 상태 종료
        currentState = newState; // 새 상태로 교체
        currentState?.Enter(); // 새 상태 시작
    }

    void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
