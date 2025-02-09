using System;
using UnityEngine;

public class PlayerSprinting : MonoBehaviour
{
	public readonly ReactiveProperty<bool> IsSprinting = new();
	
	private Player _player;
	
	private void Awake()
	{
		_player = GetComponent<Player>();
	}
	
	public void ChangeIsSprintValue()
	{
		if (_player.IsGroundedViewModel.Value == false)
		{
			throw new ArgumentException($"{gameObject.name} is not on the ground.");
		}
		if (_player.IsCrouchingViewModel.Value == true)
		{
			throw new ArgumentException($"{gameObject.name} is crouching.");
		}
		
		IsSprinting.Value = !IsSprinting.Value;
	}
}