using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<EPlayerState>
{
	[SerializeField] private Player _player;
	
	public PlayerStateMachine(Player player) 
	{
		_player = player;
	}
}