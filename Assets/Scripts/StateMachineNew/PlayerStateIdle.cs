using UnityEngine;

public class PlayerStateIdle : FiniteStateMachineState
{
	public PlayerStateIdle(FiniteStateMachine fsm) : base(fsm) {  }

	public override void Enter()
	{
		Debug.Log("Idle is entered");
	}
	
	public override void Exit()
	{
		Debug.Log("Idle is exited");
	}
	
	public override void Update()
	{
		Debug.Log("Idle is updated");
		
		if (1 == 1)
		{
			Fsm.SetState<PlayerStateWalk>();
		}
	}
}