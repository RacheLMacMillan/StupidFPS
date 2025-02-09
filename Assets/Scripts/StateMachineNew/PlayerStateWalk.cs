using UnityEngine;

public class PlayerStateWalk : FiniteStateMachineState
{
	public PlayerStateWalk(FiniteStateMachine fsm) : base(fsm) {  }

	public override void Enter()
	{
		Debug.Log("Walk is entered");
	}
	
	public override void Exit()
	{
		Debug.Log("Walk is exited");
	}
	
	public override void Update()
	{
		Debug.Log("Walk is updated");
	}
}