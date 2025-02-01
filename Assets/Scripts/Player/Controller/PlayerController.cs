using UnityEngine;

[RequireComponent(typeof(PlayerGravitation), typeof(PlayerGroundedChecker))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerLook), typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerSprinter))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	public ReactiveProperty<float> GravityValue = new();
	public ReactiveProperty<float> MoveSpeed = new();
	
	public ReactiveProperty<bool> IsGrounded = new();
	public ReactiveProperty<bool> IsCrouching = new();
	public ReactiveProperty<bool> IsSprinting = new();
	
	public ReactiveProperty<Vector3> PlayerVelocity = new();
	
	private PlayerGroundedChecker _playerGroundedChecker;
	private PlayerGravitation _playerGravitation;
	private PlayerMover _playerMover;
	private PlayerLook _playerLook;
	private PlayerJumper _playerJumper;
	private PlayerCrouching _playerCrouching;
	private PlayerSprinter _playerSprinter;

	private void OnEnable()
	{
		_playerGroundedChecker.IsGrounded.OnChanged += OnIsGroundedChanged;
		_playerCrouching.IsCrouching.OnChanged += OnCrouchingChanged;
		_playerSprinter.IsSprinting.OnChanged += OnSprintChanged;
	}
	
	private void OnDisable()
	{
		_playerGroundedChecker.IsGrounded.OnChanged -= OnIsGroundedChanged;
		_playerCrouching.IsCrouching.OnChanged -= OnCrouchingChanged;
		_playerSprinter.IsSprinting.OnChanged -= OnSprintChanged;
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
	}
	
	private void Update()
	{
		_playerGroundedChecker.CheckIsGrounded();
		
		_playerGravitation.GravitatePlayer(PlayerVelocity.Value, IsGrounded.Value);
	}
	
	public void OnMoveByTransformDirection(Vector3 direction)
	{
		_playerMover.MoveByTransformDirection(direction);
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
		_playerSprinter.ChangeIsSprintValue();
	}
	
	public void OnJump()
	{
		_playerJumper.Jump(PlayerVelocity.Value, IsGrounded.Value);
	}
	
	public void OnCrouch()
	{
		_playerCrouching.Crouch();
	}
	
	private void OnIsGroundedChanged(bool value)
	{
		IsGrounded.Value = value;
	}
	
	private void OnCrouchingChanged(bool value)
	{
		IsCrouching.Value = value;
	}
	
	private void OnSprintChanged(bool value)
	{
		IsSprinting.Value = value;
	}
}