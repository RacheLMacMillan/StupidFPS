public class Player
{
	public readonly ReactiveProperty<float> GravitationValue = new();
	public readonly ReactiveProperty<float> MoveSpeed = new();
	
	public readonly ReactiveProperty<bool> IsGrounded = new();
	public readonly ReactiveProperty<bool> IsSprinting = new();
}