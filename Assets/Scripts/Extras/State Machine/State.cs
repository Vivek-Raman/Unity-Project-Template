public abstract class State
{
    protected StateMachine source = null;

    public virtual void OnStateEnter() { }
    public virtual void OnStateTick()  { }
    public virtual void OnStateExit()  { }

    public State(StateMachine source)
    {
        this.source = source;
    }
}
