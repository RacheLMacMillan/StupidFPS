using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActionsModel : MonoBehaviour
{
	public readonly ReactiveProperty<KeyCode> ActionMoveUp = new();
	public readonly ReactiveProperty<KeyCode> ActionMoveLeft = new();
	public readonly ReactiveProperty<KeyCode> ActionMoveDown = new();
	public readonly ReactiveProperty<KeyCode> ActionMoveRight = new();
	
	
	// public PlayerInputActionsModel()
	
	private InputMap _inputMap;
	
	private void Start()
	{
		_inputMap = new InputMap();
		
		InputMap.PlaySceneActions _playScene = _inputMap.PlayScene;
		
	}
}