using UnityEngine;

[RequireComponent(typeof(PlayerGravitation), typeof(PlayerGroundedChecker))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerLook), typeof(PlayerJumper))]
public class PlayerController : MonoBehaviour
{
	public ReactiveProperty<float> MoveSpeed = new();
	public ReactiveProperty<bool> IsGrounded = new();
	
	private bool _isGrounded => IsGrounded.Value;
	
	private PlayerGroundedChecker _playerGroundedChecker;
	private PlayerGravitation _playerGravitation;
	private PlayerMover _playerMover;
	private PlayerLook _playerLook;
	private PlayerJumper _playerJumper;
	private PlayerCrouching _playerCrouching;
	private PlayerSprinter _playerSprinter;
	
	private void Awake()
	{
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		_playerGravitation = GetComponent<PlayerGravitation>();
		_playerMover = GetComponent<PlayerMover>();
		_playerLook = GetComponent<PlayerLook>();
		_playerJumper = GetComponent<PlayerJumper>();
		_playerCrouching = GetComponent<PlayerCrouching>();
		_playerSprinter = GetComponent<PlayerSprinter>();
	}
	
	private void Update()
	{
		_playerGroundedChecker.CheckIsGrounded();
	}
	
	public void OnGravitate()
	{
		_playerGravitation.GravitatePlayer();
	}
	
	public void OnMove(Vector2 direction)
	{
		_playerMover.Move(direction);
	}
	
	public void OnLook(Vector2 direction)
	{
		_playerLook.Look(direction);
	}
	
	public void OnSprint()
	{
		_playerSprinter.Sprint();
	}
	
	public void OnJump()
	{
		
	}
	
	public void OnCrouch()
	{
		
	}
}