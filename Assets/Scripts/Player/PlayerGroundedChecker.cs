using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{
	[SerializeField] LayerMask layerMask;
	
	[SerializeField] private Vector3 _radiusOfCheck;
	
	private bool _playerIsGrouded;
	
	public bool CheckIsGrounded()
	{
		_playerIsGrouded = Physics.CheckBox(transform.position, _radiusOfCheck, transform.rotation, layerMask);
		
		Debug.Log($"Player grounded - {_playerIsGrouded}");
		
		return _playerIsGrouded;
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, _radiusOfCheck);
	}
}