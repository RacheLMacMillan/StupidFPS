using UnityEngine;
using UnityEngine.Assertions;

public class PlayerStateMachine : StateManager<EPlayerState>
{
	[SerializeField] private PlayerController _playerViewModel;
	
	private PlayerStateContext _context;
	
	public void Awake()
	{
		_playerViewModel = GetComponent<PlayerController>();
		
		ValidateConstraints();
		
		_context = new PlayerStateContext(_playerViewModel);
		
		InitializeStates();
	}
	
	private void ValidateConstraints()
	{
		Assert.IsNotNull(_playerViewModel, "Player view model is not assigned.");
	}
	
	private void InitializeStates()
	{
		States.Add(EPlayerState.Idle, new IdleState(_context, EPlayerState.Idle));
		States.Add(EPlayerState.Walking, new WalkingState(_context, EPlayerState.Walking));
		States.Add(EPlayerState.Crouching, new CrouchingState(_context, EPlayerState.Crouching));
		States.Add(EPlayerState.Sprinting, new SprintingState(_context, EPlayerState.Sprinting));
		
		CurrentState = States[EPlayerState.Idle];
	}
}