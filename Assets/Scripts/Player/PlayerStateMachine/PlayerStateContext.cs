public class PlayerStateContext
{
	public PlayerViewModel PlayerViewModelConstraint { get; private set; }
	
	public PlayerStateContext(PlayerViewModel playerViewModel)
	{
		PlayerViewModelConstraint = playerViewModel;
	}
}