using UnityEngine;

public class PlayerAbleToStandUpChecker : MonoBehaviour
{
	public readonly ReactiveProperty<bool> AbleToStandUp = new();
	
	[SerializeField] private LayerMask _groundLayer;
	
	[SerializeField] private Vector3 _standUpCheckPosition;
	[SerializeField] private float _radiusOfStandUpCheck;
	
	private PlayerPositionScaler _scaler;
	
	private void Awake()
	{
		_scaler = GetComponent<PlayerPositionScaler>();
	}
	
	public void CheckAbleToStandUp()
	{
		AbleToStandUp.Value = Physics.CheckSphere
		(
			ScalePosition(),	
			_radiusOfStandUpCheck, 
			_groundLayer
		);
	}
	
	private Vector3 ScalePosition()
	{
		return new Vector3(transform.localPosition.x + _standUpCheckPosition.x, transform.localPosition.y + _standUpCheckPosition.y, transform.localPosition.z + _standUpCheckPosition.z);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere
		(
			ScalePosition(), 
			_radiusOfStandUpCheck
		);
	}
}