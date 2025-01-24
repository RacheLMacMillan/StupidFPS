using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundedChecker))]
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _playerSpeed;
	[SerializeField] private float _speedMultiplier = 1f;
	
	private CharacterController _characterController;
	private PlayerGroundedChecker _playerGroundedChecker;
	
	private Vector3 _moveDirection;
	
	private bool _isPlayerSprinting = false;
	
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		
	}
	
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
}