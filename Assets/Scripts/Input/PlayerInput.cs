using UnityEngine;

[RequireComponent(typeof(PlayerGravitation), typeof(PlayerGroundedChecker))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerLook), typeof(PlayerJumper))]
public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	private PlayerGravitation _playerGravitation;
	private PlayerGroundedChecker _playerGroundedChecker;
	private PlayerMover _playerMover;
	private PlayerLook _playerLook;
	private PlayerJumper _playerJumper;
	private PlayerCrouching _playerCrouching;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisabel() => _inputMap.Disable();
	
	private void Awake()
	{
		_inputMap = new InputMap();
		
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		_playerGravitation = GetComponent<PlayerGravitation>();
		_playerMover = GetComponent<PlayerMover>();
		_playerLook = GetComponent<PlayerLook>();
		_playerJumper = GetComponent<PlayerJumper>();
		_playerCrouching = GetComponent<PlayerCrouching>();
		
		_inputMap.PlayScene.Sprint.performed += context => _playerMover.Sprint();
		_inputMap.PlayScene.Jump.performed += context => _playerJumper.Jump();
		_inputMap.PlayScene.Crouch.performed += context => _playerCrouching.Crouch();
	}
	
	private void Update()
	{
		_playerGroundedChecker.CheckIsGrounded();
		_playerGravitation.GravitatePlayer();
		_playerMover.Move(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		_playerLook.Look(_inputMap.PlayScene.Look.ReadValue<Vector2>());
	}
}