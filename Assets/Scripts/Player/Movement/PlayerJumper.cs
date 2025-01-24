using System;
using UnityEngine;

[RequireComponent(typeof(PlayerGravitation), typeof(PlayerGroundedChecker))]
public class PlayerJumper : MonoBehaviour
{
	[SerializeField] private float _jumpForce;
	
	[SerializeField] private Vector3 _jumpingStartUp;
	
	private PlayerGroundedChecker _playerGroundedChecker;
	private PlayerGravitation _playerGravitation;

	public void Awake()
	{
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		_playerGravitation = GetComponent<PlayerGravitation>();
	}
	
	public void Jump()
	{		
		if (_playerGroundedChecker.IsPlayerGrounded.Value == false)
		{
			throw new ArgumentException();
		}
		
		transform.position += _jumpingStartUp;
		
		_playerGravitation.PlayerVelocity.y = Mathf.Sqrt(-_jumpForce * _playerGravitation.GetGravityValue());
	}
}