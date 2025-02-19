using UnityEngine;

public class PlayerIdleState : PlayerState
{
	public PlayerIdleState(PlayerStateContext context, EPlayerState EState) : base(context, EState)
	{
		PlayerStateContext Context = context;
	}

	public override void EnterState()
	{
		Debug.Log("Entre Idle State");
	}

	public override void ExitState()
	{
		Debug.Log("Exit Idle State");
	}

	public override void UpdateState()
	{
		Debug.Log("Update Idle State");
	}

	public override EPlayerState GetNextState()
	{
		return StateKey;
	}
}