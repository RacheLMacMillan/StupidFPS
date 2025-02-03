public class SprintingState : PlayerState
{
	public SprintingState(PlayerStateContext context, EPlayerState esState) : base (context, esState)
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