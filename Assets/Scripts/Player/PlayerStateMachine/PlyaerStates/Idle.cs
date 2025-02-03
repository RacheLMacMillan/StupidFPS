using UnityEngine;
public class IdleState : PlayerState
{
	public IdleState(PlayerStateContext context, EPlayerState esState) : base (context, esState)
	{
		PlayerStateContext Context = context;
	}
	
	public override void EnterState()
	{
		Debug.Log("Entering idle state");
	}
	public override void ExitState(){}
	public override void UpdateState()
	{
		Debug.Log("Entering update state");
	}
	public override EPlayerState GetNextState()
	{
		return StateKey;
	}
}