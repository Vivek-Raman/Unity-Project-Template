using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState = null;
    public State initialState = null;

    protected void Start()
    {
        currentState = initialState;
    }

    protected void Update()
    {
        currentState?.OnStateTick();
    }

    public void SetState(State toSet)
    {
        currentState?.OnStateExit();
        currentState = toSet;
        currentState.OnStateEnter();
    }
}
