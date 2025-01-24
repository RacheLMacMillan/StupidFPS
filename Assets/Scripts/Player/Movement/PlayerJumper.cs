using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerJumper : MonoBehaviour
{
	[SerializeField] private float _jumpForce;
	
	[SerializeField] private Vector3 _jumpingStartUp;
	
	private PlayerController _playerController;

	public void Awake()
	{
		_playerController = GetComponent<PlayerController>();
	}
	
	public void Jump(Vector3 playerVelocity, bool isGrounded)
	{	
		Debug.Log("Jumping");
		if (isGrounded == false)
		{
			throw new ArgumentException();
		}
		
		transform.position += _jumpingStartUp;
		
		playerVelocity.y = Mathf.Sqrt(-_jumpForce * -9.8f);
		
		_playerController.PlayerVelocity.Value = playerVelocity;
		Debug.Log("Jumped");
	}
}