using UnityEngine;

[RequireComponent(typeof(PlayerViewModel))]
public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	private PlayerViewModel _playerController;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisabel() => _inputMap.Disable();
	
	private void Awake()
	{
		_inputMap = new InputMap();
		InputMap.PlaySceneActions playSceneActions = _inputMap.PlayScene;
		
		_playerController = GetComponent<PlayerViewModel>();
		
		playSceneActions.Jump.performed += context => _playerController.OnJump();
		playSceneActions.Crouch.performed += context => _playerController.OnCrouch();
		playSceneActions.Sprint.performed += context => _playerController.OnSprint();
	}
	
	private void Update()
	{
		Vector3 correctMoveDirection = CorrectMoveDirection(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		
		_playerController.OnMoveByTransformDirection(correctMoveDirection);
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