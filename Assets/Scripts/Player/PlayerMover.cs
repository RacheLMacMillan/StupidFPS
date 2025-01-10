using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	
	[SerializeField] private float _playerSpeed;
	
	[SerializeField] private Vector3 _moveDirection;
	
	public void Move(Vector2 direction, float speedMultiplier = 1f)
	{
		_moveDirection = new Vector3
		(
			direction.x,
			Vector2.zero.y,
			direction.y
		);

		float multiplyedSpeed = _playerSpeed * speedMultiplier;
		float scaledSpeed = multiplyedSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = _moveDirection * scaledSpeed;
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}
}