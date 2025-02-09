using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	private PlayerController _playerController;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisable() => _inputMap.Disable();
	
	private void Awake()
	{
		_inputMap = new InputMap();
		InputMap.PlaySceneActions playSceneActions = _inputMap.PlayScene;
		
		_playerController = GetComponent<PlayerController>();
		
		playSceneActions.Jump.performed += context => _playerController.OnJump();
		playSceneActions.Crouch.performed += context => _playerController.OnCrouch();
		playSceneActions.Sprint.performed += context => _playerController.OnSprint();
	}
	
	private void Update()
	{
		Vector3 correctedMoveDirection = CorrectMoveDirection(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		
		_playerController.OnMoveByTransformDirection(correctedMoveDirection);
		_playerController.OnLook(_inputMap.PlayScene.Look.ReadValue<Vector2>());	
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