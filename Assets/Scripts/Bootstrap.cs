using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private PlayerController _player;
	
	private void Awake()
	{
		_player.Initialize();
	}
}