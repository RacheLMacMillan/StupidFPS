using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerJumper : MonoBehaviour
{
	[SerializeField] private float _jumpForce;
	
	[SerializeField] private Vector3 _jumpingStartUp;
	
	private Player _player;
	private CharacterController _characterController;

	public void Awake()
	{
		_player = GetComponent<Player>();
		_characterController = GetComponent<CharacterController>();
	}
	
	public void Jump(Vector3 playerVelocity, bool isGrounded)
	{
		if (isGrounded == false)
		{
			throw new ArgumentException();
		}
		
		transform.position += _jumpingStartUp;
		
		playerVelocity.y = Mathf.Sqrt(-_jumpForce * -9.8f);
		
		_player.PlayerVelocityViewModel.Value = playerVelocity;
		
		_characterController.Move(playerVelocity * Time.deltaTime);
	}
}