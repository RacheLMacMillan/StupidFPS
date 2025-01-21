using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public readonly ReactiveProperty<float> GravitationValue = new();
	public readonly ReactiveProperty<float> MoveSpeed = new();
	
	public readonly ReactiveProperty<bool> IsGrounded = new();
	public readonly ReactiveProperty<bool> IsSprinting = new();
	
}