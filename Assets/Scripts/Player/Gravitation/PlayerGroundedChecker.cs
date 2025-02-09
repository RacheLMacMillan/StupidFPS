using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsGrounded = new();
	
	[SerializeField] private LayerMask _toStandLayer;
	
	[SerializeField] private float _radiusOfCheck;
	
	public void CheckIsGrounded()
	{
		IsGrounded.Value = Physics.CheckSphere(ScalePosition(), _radiusOfCheck, _toStandLayer);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(ScalePosition(), _radiusOfCheck);
	}
	
	private Vector3 ScalePosition()
	{
		Vector3 playerPosition = transform.localPosition;
		
		return new Vector3(playerPosition.x, playerPosition.y + _radiusOfCheck - 0.01f, playerPosition.z);
	}
}