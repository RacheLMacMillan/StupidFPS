using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundedChecker))]
public class PlayerGravitation : MonoBehaviour
{
	[SerializeField] private float _gravityValue;
	[SerializeField] private float _passiveStress;
	
	private CharacterController _characterController;
	private PlayerGroundedChecker _playerIsGoundedChecker;
	
	public Vector3 PlayerVelocity;
	
	public void Awake()
	{
		_characterController = GetComponent<CharacterController>();
		_playerIsGoundedChecker = GetComponent<PlayerGroundedChecker>();
	}
	
	public void GravitatePlayer()
	{
		PlayerVelocity.y += _gravityValue * Time.deltaTime;
		
		if (_playerIsGoundedChecker.IsPlayerGrounded.Value)
		{
			PlayerVelocity.y = _passiveStress;
		}

		_characterController.Move(PlayerVelocity * Time.deltaTime);
	}
	
	public float GetGravityValue()
	{
		return _gravityValue;
	}
}