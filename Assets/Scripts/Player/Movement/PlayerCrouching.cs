using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCrouching : MonoBehaviour
{	
	public readonly ReactiveProperty<bool> IsCrouching = new();
	
	[SerializeField, Range(0, 1)] private float _crouchingOffset;
	
	private CharacterController _characterController;
	private Transform _camera;
	
	private float _initializedBodySize;
	private Vector3 _initializedBodyCenter;
	private Vector3 _initializedCameraPosition;
	
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
		_camera = GetComponentInChildren<Camera>().GetComponent<Transform>();
		
		_initializedBodySize = _characterController.height;
		_initializedBodyCenter = _characterController.center;
		_initializedCameraPosition = _camera.transform.localPosition;
	}
	
	public void Crouch()
	{
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
}