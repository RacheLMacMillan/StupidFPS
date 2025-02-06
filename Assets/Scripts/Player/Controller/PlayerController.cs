using UnityEngine;

public class PlayerController : MonoBehaviour, IInitializable
{
	public ReactiveProperty<float> GravityValueViewModel = new();
	public ReactiveProperty<float> MoveSpeedViewModel = new();
	
	public ReactiveProperty<bool> IsGroundedViewModel = new();
	public ReactiveProperty<bool> IsCrouchingViewModel = new();
	public ReactiveProperty<bool> IsSprintingViewModel = new();
	
	public ReactiveProperty<Vector3> PlayerVelocityViewModel = new();
	
	public PlayerGroundedChecker PlayerGroundedChecker { get; private set; }
	public PlayerGravitation PlayerGravitation { get; private set; }
	public PlayerMover PlayerMover { get; private set; }
	public PlayerLook PlayerLook { get; private set; }
	public PlayerJumper PlayerJumper { get; private set; }
	public PlayerCrouching PlayerCrouching { get; private set; }
	public PlayerSprinter PlayerSprinter { get; private set; }
	public CharacterController CharacterController { get; private set; }

	private void OnEnable()
	{
		PlayerGroundedChecker.IsGrounded.OnChanged += OnIsGroundedChanged;
		PlayerCrouching.IsCrouching.OnChanged += OnCrouchingChanged;
		PlayerSprinter.IsSprinting.OnChanged += OnSprintChanged;
	}
	
	private void OnDisable()
	{
		PlayerGroundedChecker.IsGrounded.OnChanged -= OnIsGroundedChanged;
		PlayerCrouching.IsCrouching.OnChanged -= OnCrouchingChanged;
		PlayerSprinter.IsSprinting.OnChanged -= OnSprintChanged;
	}
	
	private void Update()
	{
		PlayerGroundedChecker.CheckIsGrounded();
		
		PlayerGravitation.GravitatePlayer(PlayerVelocityViewModel.Value, IsGroundedViewModel.Value);
	}
	
	public void Initialize()
	{
		PlayerGroundedChecker = GetComponent<PlayerGroundedChecker>();
		PlayerGravitation = GetComponent<PlayerGravitation>();
		PlayerMover = GetComponent<PlayerMover>();
		PlayerLook = GetComponent<PlayerLook>();
		PlayerJumper = GetComponent<PlayerJumper>();
		PlayerCrouching = GetComponent<PlayerCrouching>();
		PlayerSprinter = GetComponent<PlayerSprinter>();
	}
	
	public void OnMoveByTransformDirection(Vector3 direction)
	{
		PlayerMover.MoveByTransformDirection(direction);
	}
	
	public void OnMove(Vector3 direction)
	{
		PlayerMover.Move(direction);
	}
	
	public void OnLook(Vector2 direction)
	{
		PlayerLook.Look(direction);
	}
	
	public void OnSprint()
	{
		PlayerSprinter.ChangeIsSprintValue();
	}
	
	public void OnJump()
	{
		PlayerJumper.Jump(PlayerVelocityViewModel.Value, IsGroundedViewModel.Value);
	}
	
	public void OnCrouch()
	{
		PlayerCrouching.Crouch();
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
}