using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private Player _player;
	
	private void Awake()
	{
		_player.Initialize();
	}
}