using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{	
	[SerializeField] private LayerMask _toStandLayer;
	
	[SerializeField] private Vector3 _radiusOfCheck;
		
	public bool CheckIsGrounded()
	{
		return Physics.CheckBox(transform.position, _radiusOfCheck, transform.rotation, _toStandLayer);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, _radiusOfCheck);
	}
}