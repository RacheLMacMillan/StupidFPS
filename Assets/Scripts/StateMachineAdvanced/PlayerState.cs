public abstract class PlayerState : BaseState<EPlayerState>
{
	protected PlayerStateContext Context;
	
	public PlayerState(PlayerStateContext context, EPlayerState stateKey) : base(stateKey)
	{
		Context = context;
	}
}