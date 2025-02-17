using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<EPlayerState>
{
	[SerializeField] private Player _player;
	
	private PlayerStateContext _context;
	
	private void Awake() 
	{
		_player = GetComponent<Player>();
		
		_context = new PlayerStateContext(_player);
	}
}