using UnityEngine;

public class PlayerInputActions : MonoBehaviour
{
	private InputMap _inputMap;
	
	[SerializeField] private PlayerMover _playerMover;
	
	private void Awake()
	{
		_inputMap = new InputMap();
		
		_playerMover = GetComponent<PlayerMover>();
	}
	
	private void OnEnable() => _inputMap.Enable();
	private void OnDisabel() => _inputMap.Disable();
	
	private void Update()
	{
		_playerMover.Move(_inputMap.PlayScene.Move.ReadValue<Vector2>());
	}
}