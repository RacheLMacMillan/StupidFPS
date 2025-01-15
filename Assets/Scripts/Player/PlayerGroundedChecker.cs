using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerGroundedChecker : MonoBehaviour
{
	public bool IsPlayerGrounded 
	{
		get => _isPlayerGrounded;
		private set => CheckIsGrounded();
	}
	
	[SerializeField] LayerMask layerMask;
	
	[SerializeField] private Vector3 _radiusOfCheck;
	
	private bool _isPlayerGrounded;
	
	public bool CheckIsGrounded()
	{
		_isPlayerGrounded = Physics.CheckBox(transform.position, _radiusOfCheck, transform.rotation, layerMask);
		
		Debug.Log("Player grounded - " + _isPlayerGrounded);
		Debug.Log("Is Player grounded - " + IsPlayerGrounded);
		
		return _isPlayerGrounded;
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, _radiusOfCheck);
	}
}