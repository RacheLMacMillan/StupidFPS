using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerGravitation : MonoBehaviour
{
	[SerializeField] private float _gravityValue;
	[SerializeField] private float _passiveStress;
	
	private PlayerController _playerController;
	
	public void Awake()
	{
		_playerController = GetComponent<PlayerController>();
	}
	
	public void GravitatePlayer(Vector3 velocity, bool isGrounded)
	{
		velocity.y += _gravityValue * Time.deltaTime;
		
		if (isGrounded == true)
		{
			velocity.y = _passiveStress;
		}
		
		_playerController.PlayerVelocity.Value = new Vector3(0, velocity.y, 0);
	}
}