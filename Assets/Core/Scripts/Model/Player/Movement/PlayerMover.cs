using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
	[field: SerializeField] public float MoveSpeed { get; private set; }
	
	[SerializeField, Range(0.25f, 1)] private float CrouchingSpeedMultiplayer;
	[SerializeField, Range(1, 2)] private float SprintingSpeedMultiplayer;
	
	private float _crouchingSpeed => MoveSpeed * CrouchingSpeedMultiplayer;
	private float _sprintingSpeed => MoveSpeed * SprintingSpeedMultiplayer;
	
	private Player _player;
	private CharacterController _characterController;

	private void Awake()
	{
		_player = GetComponent<Player>();
		_characterController = GetComponent<CharacterController>();
	}
	
	public void Move(Vector3 direction)
	{
		_characterController.Move(direction * Time.deltaTime);
	}
	
	public void MoveByTransformDirection(Vector3 direction)
	{		
		Vector3 scaledMoveDirection = direction * ScaleMoveSpeed();
		
		_characterController.Move(transform.TransformDirection(scaledMoveDirection));
	}

	private float ScaleMoveSpeed()
	{
		float scaledSpeed;
		
		if (_player.IsCrouchingViewModel.Value == true)
		{
			scaledSpeed = _crouchingSpeed;
		}
		else if (_player.IsSprintingViewModel.Value == true)
		{
			scaledSpeed = _sprintingSpeed;
		}
		else	
		{
			scaledSpeed = MoveSpeed;
		}
		
		return scaledSpeed *= Time.deltaTime;
	}
}