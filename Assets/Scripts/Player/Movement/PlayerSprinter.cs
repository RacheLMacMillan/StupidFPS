using System;
using UnityEngine;

public class PlayerSprinter : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsSprinting = new();
	
	private PlayerController _playerController;
	
	private void Awake()
	{
		_playerController = GetComponent<PlayerController>();
	}
	
	public void ChangeIsSprintValue()
	{
		if (_playerController.IsGrounded.Value == false)
		{
			throw new ArgumentException($"{gameObject.name} is not on the ground.");
		}
		if (_playerController.IsCrounching.Value == true)
		{
			throw new ArgumentException($"{gameObject.name} is crouching.");
		}
		
		IsSprinting.Value = !IsSprinting.Value;
	}
}