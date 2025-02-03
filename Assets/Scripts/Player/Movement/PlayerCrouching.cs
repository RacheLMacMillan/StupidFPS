using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCrouching : MonoBehaviour
{	
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	[SerializeField, Range(0, 1)] private float _crouchingOffset;
	[SerializeField] private LayerMask _groundLayer;
	
	[SerializeField] private Vector3 _standUpCheckPosition;
	[SerializeField] private float _radiusOfStandUpCheck;
	
	private PlayerViewModel _playerController;
	private CharacterController _characterController;
	private Transform _camera;
	
	private float _initializedBodySize;
	private Vector3 _initializedBodyCenter;
	private Vector3 _initializedCameraPosition;
	
	private void Awake()
	{
		_playerController = GetComponent<PlayerViewModel>();
		_characterController = GetComponent<CharacterController>();
		_camera = GetComponentInChildren<Camera>().GetComponent<Transform>();
		
		_initializedBodySize = _characterController.height;
		_initializedBodyCenter = _characterController.center;
		_initializedCameraPosition = _camera.transform.localPosition;
	}
	
	public void Crouch()
	{
		if (CantStandUp() == true)
		{
			throw new ArgumentException("Something is interfering from above.");
		}
		if (_playerController.IsSprintingViewModel.Value == true)
		{
			throw new ArgumentException($"{gameObject.name} is sprinting.");
		}
		
		IsCrouching.Value = !IsCrouching.Value;
		
		if (IsCrouching.Value == true)
		{
			_characterController.height *= _crouchingOffset;
			_characterController.center = new Vector3(0, _characterController.center.y * _crouchingOffset, 0);
			
			_camera.localPosition = new Vector3(0, _camera.position.y * _crouchingOffset, 0);
		}
		else
		{
			_characterController.height = _initializedBodySize;
			_characterController.center = _initializedBodyCenter;
			
			_camera.localPosition = _initializedCameraPosition;
		}
	}
	
	private bool CantStandUp()
	{
		return Physics.CheckSphere(ScalePostition(), _radiusOfStandUpCheck, _groundLayer);
	}
	
	private Vector3 ScalePostition()
	{
		Vector3 playerPosition = transform.localPosition;
		
		return new Vector3(playerPosition.x, playerPosition.y + _standUpCheckPosition.y, playerPosition.z);
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(ScalePostition(), _radiusOfStandUpCheck);
	}
}