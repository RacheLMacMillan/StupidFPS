using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsPlayerGrounded = new();
	
	[SerializeField] private LayerMask _toStandLayer;
	
	[SerializeField] private Vector3 _radiusOfCheck;
	
	private bool _isPlayerGrounded;
	
	public bool CheckIsGrounded()
	{
		_isPlayerGrounded = Physics.CheckBox(transform.position, _radiusOfCheck, transform.rotation, _toStandLayer);
		
		IsPlayerGrounded.Value = _isPlayerGrounded;
		
		return IsPlayerGrounded.Value;
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, _radiusOfCheck);
	}
}