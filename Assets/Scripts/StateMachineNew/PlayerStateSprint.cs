using UnityEngine;

public class PlayerStateSprint : FiniteStateMachineState
{
	public PlayerStateSprint(FiniteStateMachine fsm) : base(fsm) {  }

	public override void Enter()
	{
		Debug.Log("Sprint is entered");
	}
	
	public override void Exit()
	{
		Debug.Log("Sprint is exited");
	}
	
	public override void Update()
	{
		Debug.Log("Sprint is updated");
	}
}