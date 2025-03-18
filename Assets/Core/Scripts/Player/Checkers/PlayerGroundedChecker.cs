using UnityEngine;

public class PlayerGroundedChecker : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsGrounded = new();
	
	[SerializeField] private LayerMask _toStandLayer;
	[SerializeField] private Vector3 _positionOfCheck;
	[SerializeField] private float _radiusOfCheck;
	
	private PlayerPositionScaler _scaler;
	
	private void Awake()
	{
		_scaler = GetComponent<PlayerPositionScaler>();
	}
	
	public void CheckIsGrounded()
	{
		IsGrounded.Value = Physics.CheckSphere
		(
			ScalePosition(), 
			_radiusOfCheck, 
			_toStandLayer
		);
	}
	
	private Vector3 ScalePosition()
	{
		return new Vector3
		(
			transform.localPosition.x + _positionOfCheck.x, 
			transform.localPosition.y + _positionOfCheck.y, 
			transform.localPosition.z + _positionOfCheck.z
		);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere
		(
			ScalePosition(), 
			_radiusOfCheck
		);
	}
}