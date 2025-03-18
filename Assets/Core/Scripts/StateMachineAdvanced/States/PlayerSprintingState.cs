public class PlayerSprintingState : PlayerState
{
	public PlayerSprintingState(PlayerStateContext context, EPlayerState EState) : base(context, EState)
	{
		PlayerStateContext Context = context;
	}

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override EPlayerState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}