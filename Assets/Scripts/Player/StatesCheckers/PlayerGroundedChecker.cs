using UnityEditor.Rendering.Universal;
using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{	
	[SerializeField] private LayerMask _toStandLayer;
	
	[SerializeField] private float _radiusOfCheck;
	
	public bool CheckIsGrounded()
	{
		return Physics.CheckSphere(ScalePostition(), _radiusOfCheck, _toStandLayer);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(ScalePostition(), _radiusOfCheck);
	}
	
	private Vector3 ScalePostition()
	{
		Vector3 playerPosition = transform.localPosition;
		
		return new Vector3(playerPosition.x, playerPosition.y + _radiusOfCheck - 0.01f, playerPosition.z);
	}
}