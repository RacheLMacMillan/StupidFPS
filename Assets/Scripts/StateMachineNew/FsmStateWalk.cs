using UnityEngine;

public class FsmStateWalk : FsmState
{
	public FsmStateWalk(Fsm fsm) : base(fsm) {  }

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