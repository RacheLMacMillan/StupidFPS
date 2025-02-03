public class CrouchingState : PlayerState
{
	public CrouchingState(PlayerStateContext context, EPlayerState esState) : base (context, esState)
	{
		PlayerStateContext Context = context;
	}
	
	public override void EnterState(){}
	public override void ExitState(){}
	public override void UpdateState(){}
	public override EPlayerState GetNextState()
	{
		return StateKey;
	}
}