using UnityEngine;

public class PlayerStateCrouch : FiniteStateMachineState
{
	public PlayerStateCrouch(FiniteStateMachine fsm) : base(fsm) {  }

	public override void Enter()
	{
		Debug.Log("Crouch is entered");
	}
	
	public override void Exit()
	{
		Debug.Log("Crouch is exited");
	}
	
	public override void Update()
	{
		Debug.Log("Crouch is updated");
	}
}