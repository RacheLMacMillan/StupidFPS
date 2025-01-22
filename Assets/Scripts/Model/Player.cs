using UnityEngine;

public class Player : MonoBehaviour
{
	public readonly ReactiveProperty<float> GravitationValue = new();
	public readonly ReactiveProperty<float> MoveSpeed = new();
	
	public readonly ReactiveProperty<bool> IsGrounded = new();
	public readonly ReactiveProperty<bool> IsSprinting = new();
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	[SerializeField] private float _gravitationValue;
	[SerializeField] private float _moveSpeed;
	
	[SerializeField] private bool _isGrounded;
	[SerializeField] private bool _isSprinting;
	[SerializeField] private bool _isCrouching;
	
	private void Awake()
	{
		GravitationValue.Value = _gravitationValue;
		MoveSpeed.Value = _moveSpeed;
		
		IsGrounded.Value = _isGrounded;
		IsSprinting.Value = _isSprinting;
		IsCrouching.Value = _isCrouching;
	}
}