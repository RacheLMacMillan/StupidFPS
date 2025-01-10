using UnityEngine;

public class PlayerInputActions : MonoBehaviour
{
	private InputMap _inputMap;
	
	[SerializeField] private PlayerMover _playerMover;
	[SerializeField] private PlayerLook _playerLook;
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisabel() => _inputMap.Disable();
	
	private void Awake()
	{
		_inputMap = new InputMap();
		
		_playerMover = GetComponent<PlayerMover>();
	}
	
	private void Update()
	{
		_playerMover.Move(_inputMap.PlayScene.Move.ReadValue<Vector2>());
		_playerLook.Look(_inputMap.PlayScene.Look.ReadValue<Vector2>());
	}
}