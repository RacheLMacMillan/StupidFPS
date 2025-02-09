public abstract class FiniteStateMachineState
{
	protected readonly FiniteStateMachine Fsm;
	
	public FiniteStateMachineState(FiniteStateMachine fsm)
	{
		Fsm = fsm;
	}
	
	public virtual void Enter() {  }
	public virtual void Exit() {  }
	public virtual void Update() {  }
	
}