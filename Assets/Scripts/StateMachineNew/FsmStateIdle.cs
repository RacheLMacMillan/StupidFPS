using UnityEngine;

public class FsmStateIdle : FsmState
{
	public FsmStateIdle(Fsm fsm) : base(fsm) {  }

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
			Fsm.SetState<FsmStateWalk>();
		}
	}
}