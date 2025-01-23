using UnityEngine;

public class PlayerDefaultStats : MonoBehaviour
{	
	public readonly ReactiveProperty<float> GravitationValue = new();
	public readonly ReactiveProperty<float> MoveSpeed = new();
	public readonly ReactiveProperty<float> SprintingSpeed = new();
	public readonly ReactiveProperty<float> CrouchingSpeed = new();
	
	public readonly ReactiveProperty<bool> IsGrounded = new();
	public readonly ReactiveProperty<bool> IsSprinting = new();
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	[SerializeField] private float _gravitationValue;
	[SerializeField] private float _moveSpeed;
	[SerializeField, Range(0, 1)] private float _sprintingSpeed;
	[SerializeField, Range(0, 1)] private float _crouchingSpeed;
	
	[SerializeField] private bool _isGrounded;
	[SerializeField] private bool _isSprinting;
	[SerializeField] private bool _isCrouching;

	private void Awake()
	{
		GravitationValue.Value = _gravitationValue;
		MoveSpeed.Value = _moveSpeed;
		SprintingSpeed.Value = _sprintingSpeed;
		CrouchingSpeed.Value = _crouchingSpeed;
		
		IsGrounded.Value = _isGrounded;
		IsSprinting.Value = _isSprinting;
		IsCrouching.Value = _isCrouching;
	}
}