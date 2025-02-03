using System;
using UnityEngine;

public class PlayerSprinter : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsSprinting = new();
	
	private PlayerViewModel _playerController;
	
	private void Awake()
	{
		_playerController = GetComponent<PlayerViewModel>();
	}
	
	public void ChangeIsSprintValue()
	{
		if (_playerController.IsGroundedViewModel.Value == false)
		{
			throw new ArgumentException($"{gameObject.name} is not on the ground.");
		}
		if (_playerController.IsCrouchingViewModel.Value == true)
		{
			throw new ArgumentException($"{gameObject.name} is crouching.");
		}
		
		IsSprinting.Value = !IsSprinting.Value;
	}
}