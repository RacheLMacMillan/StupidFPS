using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	
	[SerializeField] private float _playerSpeed;
	[SerializeField] private float _speedMultiplier = 1f;
	
	private Vector3 _moveDirection;
	
	private bool _isPlayerSprinting = false;
	
	public void Move(Vector2 direction)
	{
		_moveDirection = new Vector3
		(
			direction.x,
			Vector2.zero.y,
			direction.y
		);

		float multiplyedSpeed = _playerSpeed * _speedMultiplier;
		float scaledSpeed = multiplyedSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = _moveDirection * scaledSpeed;
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}
	
	public void Sprint()
	{
		if(_characterController.isGrounded == false)
		{
			throw new ArgumentException($"{gameObject.name} is not on the ground.");
		}
		
		_isPlayerSprinting = !_isPlayerSprinting;
		
		if(_isPlayerSprinting == true)
		{
			_speedMultiplier = 1.5f;
		}
		else
		{
			_speedMultiplier = 1f;
		}
	}
}