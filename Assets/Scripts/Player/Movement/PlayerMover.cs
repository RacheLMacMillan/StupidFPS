using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundedChecker))]
public class PlayerMover : MonoBehaviour, IMoveable
{
	[field: SerializeField] public float MoveSpeed { get; set; }
	
	private float _defaulMoveSpeed;
	
	private PlayerController _playerController;
	private CharacterController _characterController;

    private void Awake()
	{
		_playerController = GetComponent<PlayerController>();
		_characterController = GetComponent<CharacterController>();
	}
	
	private void OnEnable()
	{
		_playerController.IsCrounching.OnChanged += OnIsCrouchingChanged;
		_playerController.IsSprinting.OnChanged += OnIsSprintingChanged;
	}
	
	private void OnDisable()
	{
		_playerController.IsCrounching.OnChanged -= OnIsCrouchingChanged;
		_playerController.IsSprinting.OnChanged -= OnIsSprintingChanged;
	}
	
	public void Move(Vector3 direction)
	{
		_characterController.Move(direction * Time.deltaTime);
	}
	
	public void MoveByTransoformDirection(Vector3 direction)
	{
		float scaledSpeed = MoveSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = direction * scaledSpeed;
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}
	
	private void OnIsCrouchingChanged(bool value)
	{
		if (value == true)
		{
			_defaulMoveSpeed = MoveSpeed;
			MoveSpeed /= 2;
		}
		else
		{
			MoveSpeed = _defaulMoveSpeed;
		}
	}
	
	private void OnIsSprintingChanged(bool value)
	{
		if (value == true)
		{
			_defaulMoveSpeed = MoveSpeed;
			MoveSpeed *= 2;
		}
		else
		{
			MoveSpeed = _defaulMoveSpeed;
		}
	}
}