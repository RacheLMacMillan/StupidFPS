using UnityEngine;

[RequireComponent(typeof(PlayerGravitation), typeof(PlayerGroundedChecker))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerLook), typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerSprinter))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	public ReactiveProperty<float> MoveSpeed = new();
	
	public ReactiveProperty<bool> IsGrounded = new();
	
	public ReactiveProperty<Vector3> PlayerVelocity = new();
	
	public PlayerGroundedChecker _playerGroundedChecker { get; private set; }
	public PlayerGravitation _playerGravitation { get; private set; }
	public PlayerMover _playerMover { get; private set; }
	public PlayerLook _playerLook { get; private set; }
	public PlayerJumper _playerJumper { get; private set; }
	public PlayerCrouching _playerCrouching { get; private set; }
	public PlayerSprinter _playerSprinter { get; private set; }
	
	public CharacterController _characterController { get; private set; }
	
	private void OnEnable()
	{
		
	}
	
	private void OnDisable()
	{
		
	}
	
	private void Awake()
	{	
		_playerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		_playerGravitation = GetComponent<PlayerGravitation>();
		_playerMover = GetComponent<PlayerMover>();
		_playerLook = GetComponent<PlayerLook>();
		_playerJumper = GetComponent<PlayerJumper>();
		_playerCrouching = GetComponent<PlayerCrouching>();
		_playerSprinter = GetComponent<PlayerSprinter>();
		
		_characterController = GetComponent<CharacterController>();
	}
	
	private void Update()
	{
		IsGrounded.Value = _playerGroundedChecker.CheckIsGrounded();
		
		_playerGravitation.GravitatePlayer(PlayerVelocity.Value, IsGrounded.Value);
		
		Debug.Log(IsGrounded.Value);
	}
	
	public void OnMoveByTransoformDirection(Vector3 direction)
	{
		_playerMover.MoveByTransoformDirection(direction);
	}
	
	public void OnMove(Vector3 direction)
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
		_playerJumper.Jump(PlayerVelocity.Value, IsGrounded.Value);
	}
	
	public void OnCrouch()
	{
		_playerCrouching.Crouch();
	}
	
	private void OnPlayerVelocityChanged(Vector3 velocity)
	{
		PlayerVelocity.Value = velocity;
	}
}