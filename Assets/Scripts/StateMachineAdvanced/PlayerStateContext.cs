public class PlayerStateContext
{
	public Player Player { get; private set; }
	
	public PlayerStateContext(Player player)
	{
		Player = player;
	}
}