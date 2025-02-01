using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundedChecker))]
public class PlayerMover : MonoBehaviour
{
	[field: SerializeField] public float MoveSpeed { get; private set; }
	[field: SerializeField, Range(0, 1)] public float CrouchingSpeedMultiplayer { get; private set; }
	[field: SerializeField, Range(1, 2)] public float SprintingSpeedMultiplayer { get; private set; }
	
	private float _defaultMoveSpeed;
	
	private PlayerController _playerController;
	private CharacterController _characterController;

    private void Awake()
	{
		_playerController = GetComponent<PlayerController>();
		_characterController = GetComponent<CharacterController>();
	}
	
	private void OnEnable()
	{
		_playerController.IsCrouching.OnChanged += OnIsCrouchingChanged;
		_playerController.IsSprinting.OnChanged += OnIsSprintingChanged;
	}
	
	private void OnDisable()
	{
		_playerController.IsCrouching.OnChanged -= OnIsCrouchingChanged;
		_playerController.IsSprinting.OnChanged -= OnIsSprintingChanged;
	}
	
	public void Move(Vector3 direction)
	{
		_characterController.Move(direction * Time.deltaTime);
	}
	
	public void MoveByTransformDirection(Vector3 direction)
	{
		float scaledSpeed = MoveSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = direction * scaledSpeed;
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}
	
	private void OnIsCrouchingChanged(bool value)
	{
		if (value == true)
		{
			_defaultMoveSpeed = MoveSpeed;
			MoveSpeed *= CrouchingSpeedMultiplayer;
		}
		else
		{
			MoveSpeed = _defaultMoveSpeed;
		}
	}
	
	private void OnIsSprintingChanged(bool value)
	{
		if (value == true)
		{
			_defaultMoveSpeed = MoveSpeed;
			MoveSpeed *= SprintingSpeedMultiplayer;
		}
		else
		{
			MoveSpeed = _defaultMoveSpeed;
		}
	}
}