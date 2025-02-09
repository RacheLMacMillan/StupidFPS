using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	private Player _player;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisable() => _inputMap.Disable();
	
	public PlayerInput(Player player)
	{
		_player = player;
		
		_inputMap = new InputMap();
		InputMap.PlaySceneActions playSceneActions = _inputMap.PlayScene;
		
		playSceneActions.Jump.performed += context => _player.OnJump();
		playSceneActions.Crouch.performed += context => _player.OnCrouch();
		playSceneActions.Sprint.performed += context => _player.OnSprint();
	}
	
	private void Update()
	{
		Vector3 correctedMoveDirection = CorrectMoveDirection(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		
		_player.OnMoveByTransformDirection(correctedMoveDirection);
		_player.OnLook(_inputMap.PlayScene.Look.ReadValue<Vector2>());	
	}
	
	private Vector3 CorrectMoveDirection(Vector2 direction)
	{
		Vector3 correctedDirection = new Vector3
		(
			direction.x,
			0,
			direction.y
		);
		
		return correctedDirection;
	}
}