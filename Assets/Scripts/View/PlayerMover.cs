using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _playerSpeed;
	
	public void Move(Vector2 direction, float speedMultiplier = 1f)
	{
		Vector3 moveDirection = new Vector3
		(
			direction.x,
			Vector2.zero.y,
			direction.y
		);

		float multiplyedSpeed = _playerSpeed * speedMultiplier;
		float scaledSpeed = multiplyedSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = moveDirection * scaledSpeed;
		
		transform.position += scaledMoveDirection;
	}
}