using UnityEngine;

[RequireComponent(typeof(Player))]
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
		playSceneActions.Dash.performed += context => _player.OnDash(playSceneActions.Move.ReadValue<Vector2>());
	}
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisable() => _inputMap.Disable();
	
	private void Update()
	{
		Vector2 moveDirection = _inputMap.PlayScene.Move.ReadValue<Vector2>();
		Vector3 correctedMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
		
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
}