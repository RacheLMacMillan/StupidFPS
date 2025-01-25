using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerGroundedChecker))]
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _playerSpeed;
	[SerializeField] private float _speedMultiplier = 1f;
	
	private CharacterController _characterController;
		
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}
	
	public void Move(Vector3 direction)
	{
		_characterController.Move(direction * Time.deltaTime);
	}
	
	public void MoveByTransoformDirection(Vector3 direction)
	{
		float scaledSpeed = _playerSpeed * Time.deltaTime;
				
		Vector3 scaledMoveDirection = direction * scaledSpeed;
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}
}