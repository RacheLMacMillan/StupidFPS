using UnityEngine;

public class PlayerAbleToStandUpChecker : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsAbleToStandUp = new();
	
	[SerializeField] private LayerMask _groundLayer;
	
	[SerializeField] private Vector3 _standUpCheckPosition;
	[SerializeField] private float _radiusOfStandUpCheck;
	
	public void CheckAbleToStandUp()
	{
		if (Physics.CheckSphere(ScalePosition(), _radiusOfStandUpCheck, _groundLayer) == true) //if there is something up above the player, you can't stand up
		{
			IsAbleToStandUp.Value = false;
		}
		else
		{
			IsAbleToStandUp.Value = true;
		}
	}
	
	private Vector3 ScalePosition()
	{
		return new Vector3
		(
			transform.localPosition.x + _standUpCheckPosition.x, 
			transform.localPosition.y + _standUpCheckPosition.y, 
			transform.localPosition.z + _standUpCheckPosition.z
		);
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