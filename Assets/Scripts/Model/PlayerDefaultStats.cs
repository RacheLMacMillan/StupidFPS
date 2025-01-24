using UnityEngine;

public class PlayerDefaultStats : MonoBehaviour
{	
	[Header("Gravitation")]
	public readonly ReactiveProperty<float> GravitationValue = new();
	
	[Header("Movement")]
	public readonly ReactiveProperty<float> MoveSpeed = new();
	public readonly ReactiveProperty<float> JumpForce = new();
	public readonly ReactiveProperty<float> SprintingSpeed = new();
	public readonly ReactiveProperty<float> CrouchingSpeed = new();
	
	public readonly ReactiveProperty<Vector3> JumpingStartUp = new();
	
	public readonly ReactiveProperty<bool> IsGrounded = new();
	public readonly ReactiveProperty<bool> IsSprinting = new();
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	public readonly ReactiveProperty<float> SensitivityByX = new();
	public readonly ReactiveProperty<float> SensitivityByY = new();
	public readonly ReactiveProperty<float> MinVerticalRotation = new();
	public readonly ReactiveProperty<float> MaxVerticalRotation = new();
	
	[Header("Graviation")]
	[SerializeField] private float _gravitationValue;
	
	[Header("Movement")]
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _jumpForce;
	[SerializeField, Range(0, 1)] private float _sprintingSpeed;
	[SerializeField, Range(0, 1)] private float _crouchingSpeed;
	
	[SerializeField] private Vector3 _jumpingStartUp;
	
	[SerializeField] private bool _isGrounded;
	[SerializeField] private bool _isSprinting;
	[SerializeField] private bool _isCrouching;
	
	[Header("Settings")]
	[SerializeField] private float _sensitivityByX;
	[SerializeField] private float _sensitivityByY;
	[SerializeField] private float _minVerticalRotation;
	[SerializeField] private float _maxVerticalRotation;

	private void Awake()
	{
		GravitationValue.Value = _gravitationValue;
		MoveSpeed.Value = _moveSpeed;
		JumpForce.Value = _jumpForce;
		SprintingSpeed.Value = _sprintingSpeed;
		CrouchingSpeed.Value = _crouchingSpeed;
		
		JumpingStartUp.Value = _jumpingStartUp;
		
		IsGrounded.Value = _isGrounded;
		IsSprinting.Value = _isSprinting;
		IsCrouching.Value = _isCrouching;
		
		SensitivityByX.Value = _sensitivityByX;
		SensitivityByY.Value = _sensitivityByY;
		MinVerticalRotation.Value = _minVerticalRotation;
		MaxVerticalRotation.Value = _maxVerticalRotation;
		
		Debug.Log(MoveSpeed.Value);
	}
}