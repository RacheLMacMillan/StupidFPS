public class PlayerStateContext
{
	public PlayerController PlayerViewModelConstraint { get; private set; }
	
	public PlayerStateContext(PlayerController playerViewModel)
	{
		PlayerViewModelConstraint = playerViewModel;
	}
}