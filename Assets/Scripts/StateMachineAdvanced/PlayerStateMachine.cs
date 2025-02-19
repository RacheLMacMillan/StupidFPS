using UnityEngine;

public class PlayerStateMachine : BaseStateMachine<EPlayerState>
{
	[SerializeField] private Player _player;
	
	private PlayerStateContext _context;
	
	private void Awake() 
	{
		_player = GetComponent<Player>();
		
		_context = new PlayerStateContext(_player);
		
		InitializeStates();
	}
	
	private void InitializeStates()
	{
		States.Add(EPlayerState.Idle, new PlayerIdleState(_context, EPlayerState.Idle));
		States.Add(EPlayerState.Walking, new PlayerWalkingState(_context, EPlayerState.Walking));
		States.Add(EPlayerState.Crouching, new PlayerCrouchingState(_context, EPlayerState.Crouching));
		States.Add(EPlayerState.Sprinting, new PlayerSprintingState(_context, EPlayerState.Sprinting));
		
		CurrentState = States[EPlayerState.Idle];
	}
}