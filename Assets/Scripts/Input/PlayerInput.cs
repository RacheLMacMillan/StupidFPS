using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private InputMap _inputMap;
	
	[SerializeField] private PlayerGravitation _playerGravitation;
	[SerializeField] private PlayerGroundedChecker _playerGroundedChecker;
	[SerializeField] private PlayerMover _playerMover;
	[SerializeField] private PlayerLook _playerLook;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisabel() => _inputMap.Disable();
	
	private void Awake()
	{
		_inputMap = new InputMap();
		
		_playerMover = GetComponent<PlayerMover>();
		_playerLook = GetComponent<PlayerLook>();
		_playerGravitation = GetComponent<PlayerGravitation>();
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		
		_inputMap.PlayScene.Sprint.performed += context => _playerMover.Sprint();
	}
	
	private void Update()
	{
		_playerGravitation.GravitatePlayer();
		_playerGroundedChecker.CheckIsGrounded();
		_playerMover.Move(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		_playerLook.Look(_inputMap.PlayScene.Look.ReadValue<Vector2>());
	}
}