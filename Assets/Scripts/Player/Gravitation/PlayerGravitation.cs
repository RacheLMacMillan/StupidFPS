using UnityEngine;

[RequireComponent(typeof(PlayerViewModel))]
public class PlayerGravitation : MonoBehaviour
{
	[SerializeField] private float _inspectGravityValue;
	[SerializeField] private float _passiveStress;
	
	private PlayerViewModel _playerController;
	
	public void Awake()
	{
		_playerController = GetComponent<PlayerViewModel>();
	}
	
	public void GravitatePlayer(Vector3 velocity, bool isGrounded)
	{
		velocity.y += _inspectGravityValue * Time.deltaTime;
		
		if (isGrounded == true)
		{
			velocity.y = _passiveStress;
		}
		
		_playerController.OnMove(velocity);
		
		_playerController.PlayerVelocityViewModel.Value = new Vector3(0, velocity.y, 0);
	}
}