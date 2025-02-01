public class PlayerStateMachine : StateManager<PlayerState>
{
	private void Awake()
	{
		CurrentState = States[PlayerState.Idle];
	}
}