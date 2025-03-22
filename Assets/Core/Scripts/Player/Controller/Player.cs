using UnityEngine;

[RequireComponent(typeof(PlayerGroundedChecker))]
[RequireComponent(typeof(PlayerAbleToStandUpChecker))]

[RequireComponent(typeof(PlayerGravitation))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerCrouching))]
[RequireComponent(typeof(PlayerSprinting))]
[RequireComponent(typeof(PlayerDasher))]

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour, IInitializable
{
	public ReactiveProperty<float> GravityValueViewModel = new();
	public ReactiveProperty<float> MoveSpeedViewModel = new();
	public ReactiveProperty<Vector3> MoveDirection = new();
	public ReactiveProperty<Vector3> LookDirection = new();
	
	public ReactiveProperty<bool> IsGroundedViewModel = new();
	public ReactiveProperty<bool> IsCrouchingViewModel = new();
	public ReactiveProperty<bool> IsSprintingViewModel = new();
	public ReactiveProperty<bool> IsAbleToStandUpViewModel = new();
	
	public ReactiveProperty<Vector3> PlayerVelocityViewModel = new();
	
	public PlayerGroundedChecker PlayerGroundedChecker { get; private set; }
	public PlayerAbleToStandUpChecker PlayerAbleToStandUpChecker { get; private set; }
	
	public PlayerGravitation PlayerGravitation { get; private set; }
	public PlayerMover PlayerMover { get; private set; }
	public PlayerLook PlayerLook { get; private set; }
	public PlayerJumper PlayerJumper { get; private set; }
	public PlayerCrouching PlayerCrouching { get; private set; }
	public PlayerSprinting PlayerSprinting { get; private set; }
	public PlayerDasher PlayerDasher { get; private set; }

	private void OnEnable()
	{
		PlayerGroundedChecker.IsGrounded.OnChanged += OnIsGroundedChanged;
		PlayerCrouching.IsCrouching.OnChanged += OnCrouchingChanged;
		PlayerSprinting.IsSprinting.OnChanged += OnSprintChanged;
		PlayerAbleToStandUpChecker.IsAbleToStandUp.OnChanged += OnAbleToStandUpChanged;
	}
	
	private void OnDisable()
	{
		PlayerGroundedChecker.IsGrounded.OnChanged -= OnIsGroundedChanged;
		PlayerCrouching.IsCrouching.OnChanged -= OnCrouchingChanged;
		PlayerSprinting.IsSprinting.OnChanged -= OnSprintChanged;
		PlayerAbleToStandUpChecker.IsAbleToStandUp.OnChanged -= OnAbleToStandUpChanged;
	}
	
	private void Update()
	{
		PlayerGroundedChecker.CheckIsGrounded();
		PlayerAbleToStandUpChecker.CheckAbleToStandUp();
		
		PlayerGravitation.GravitatePlayer(PlayerVelocityViewModel.Value, IsGroundedViewModel.Value);
	}
	
	public void Initialize()
	{
		PlayerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		PlayerAbleToStandUpChecker = GetComponent<PlayerAbleToStandUpChecker>();
		
		PlayerGravitation = GetComponent<PlayerGravitation>();
		PlayerMover = GetComponent<PlayerMover>();
		PlayerLook = GetComponent<PlayerLook>();
		PlayerJumper = GetComponent<PlayerJumper>();
		PlayerCrouching = GetComponent<PlayerCrouching>();
		PlayerSprinting = GetComponent<PlayerSprinting>();
		PlayerDasher = GetComponent<PlayerDasher>();
	}
	
	public void OnCrouchingStateEnabled()
	{
		PlayerSprinting.StopSprinting();
		PlayerCrouching.StartCrouching();
	}
	
	public void OnSprintingStateEnabled()
	{
		PlayerCrouching.StandUp();
		PlayerSprinting.StartSprinting();
	}
	
	public void OnMoveByTransformDirection(Vector3 direction)
	{
		PlayerMover.MoveByTransformDirection(direction);
	}
	
	public void OnMove(Vector3 direction)
	{
		MoveDirection.Value = direction;
		
		PlayerMover.Move(direction);
	}
	
	public void OnLook(Vector2 direction)
	{
		LookDirection.Value = direction;
		
		PlayerLook.Look(direction);
	}
	
	public void OnJump()
	{
		PlayerJumper.Jump(PlayerVelocityViewModel.Value, IsGroundedViewModel.Value);
	}
	
	public void OnCrouch()
	{
		PlayerCrouching.Crouch();
		
		PlayerSprinting.StopSprinting();
	}
	
	public void OnSprint()
	{
		PlayerSprinting.ChangeIsSprintValue();
		
		PlayerCrouching.StandUp();
	}
	
	public void OnDash(Vector2 direction)
	{
	    PlayerDasher.Dash(direction);
	}
	
	private void OnIsGroundedChanged(bool value)
	{
		IsGroundedViewModel.Value = value;
	}
	
	private void OnCrouchingChanged(bool value)
	{
		IsCrouchingViewModel.Value = value;
	}
	
	private void OnSprintChanged(bool value)
	{
		IsSprintingViewModel.Value = value;
	}
	
	private void OnAbleToStandUpChanged(bool value)
	{
		IsAbleToStandUpViewModel.Value = value;
	}
}