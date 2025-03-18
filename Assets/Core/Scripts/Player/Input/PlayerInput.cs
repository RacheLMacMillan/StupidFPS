using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	private Player _player;
	
	private void Awake()
	{
		_inputMap = new InputMap();
		InputMap.PlaySceneActions playSceneActions = _inputMap.PlayScene;
		
		_player = GetComponent<Player>();
		
		playSceneActions.Jump.performed += context => _player.OnJump();
		playSceneActions.Crouch.performed += context => _player.OnCrouch();
		playSceneActions.Sprint.performed += context => _player.OnSprint();
	}
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisable() => _inputMap.Disable();
	
	private void Update()
	{
		Vector3 correctedMoveDirection = CorrectMoveDirection(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		Vector2 lookDirection = _inputMap.PlayScene.Look.ReadValue<Vector2>();
		
		if (correctedMoveDirection != Vector3.zero)
		{
			_player.OnMoveByTransformDirection(correctedMoveDirection);
		}
		
		if (lookDirection != Vector2.zero)
		{
			_player.OnLook(lookDirection);
		}
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