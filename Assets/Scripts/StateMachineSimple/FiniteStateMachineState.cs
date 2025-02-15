public abstract class FiniteStateMachineState
{
	protected readonly FiniteStateMachine FSM;
	
	public FiniteStateMachineState(FiniteStateMachine fsm)
	{
		FSM = fsm;
	}
	
	public virtual void Enter() {  }
	public virtual void Exit() {  }
	public virtual void Update() {  }
	
}