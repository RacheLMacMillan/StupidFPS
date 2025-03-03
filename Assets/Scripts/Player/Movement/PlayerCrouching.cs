using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCrouching : MonoBehaviour
{	
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	[SerializeField, Range(0, 1)] private float _crouchingOffset;
	
	[SerializeField] private AnimationCurve animationCurve;
	
	private Player _player;
	private CharacterController _characterController;
	private Transform _camera;
	
	
	private float _initializedBodyHeight;
	private Vector3 _initializedBodyCenter;
	private Vector3 _initializedCameraPosition;
	
	private void Awake()
	{
		_player = GetComponent<Player>();
		_characterController = GetComponent<CharacterController>();
		_camera = GetComponentInChildren<Camera>().GetComponent<Transform>();
		
		_initializedBodyHeight = _characterController.height;
		_initializedBodyCenter = _characterController.center;
		_initializedCameraPosition = _camera.transform.localPosition;
	}
	
	public void Crouch()
	{
		if (IsCrouching.Value == true)
		{
			StandUp();
		}
		else
		{
			StartCrouching();
		}
	}
	
	public void StartCrouching()
	{
		IsCrouching.Value = true;		
		
		_characterController.height *= _crouchingOffset;
		_characterController.center = new Vector3(0, _characterController.center.y * _crouchingOffset, 0);
		
		_camera.localPosition = new Vector3(0, _camera.position.y * _crouchingOffset, 0);
	}
	
	public void StandUp()
	{
		CheckAvailableToStandUp();
		
		IsCrouching.Value = false;
		
		_characterController.height = _initializedBodyHeight;
		_characterController.center = _initializedBodyCenter;
		
		_camera.localPosition = _initializedCameraPosition;
	}
	
	private bool CheckAvailableToStandUp()
	{
		if (_player.IsAbleToStandUpViewModel.Value == false)
		{
			throw new ArgumentException($"Something is interfering from above of {gameObject.name}.");
		}
		else
		{
			return true;
		}
	}
}