using System;
using UnityEngine;

[RequireComponent(typeof(PlayerViewModel))]
public class PlayerJumper : MonoBehaviour
{
	[SerializeField] private float _jumpForce;
	
	[SerializeField] private Vector3 _jumpingStartUp;
	
	private PlayerViewModel _playerController;
	private CharacterController _characterController;

	public void Awake()
	{
		_playerController = GetComponent<PlayerViewModel>();
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
		
		_playerController.PlayerVelocityViewModel.Value = playerVelocity;
		
		_characterController.Move(playerVelocity * Time.deltaTime);
	}
}