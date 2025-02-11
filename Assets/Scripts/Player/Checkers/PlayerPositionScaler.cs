using UnityEngine;

public class PlayerPositionScaler : MonoBehaviour
{
	public Vector3 ScalePosition(Vector3 position, float x, float y, float z)
	{
		return new Vector3(position.x + x, position.y + y, position.z + z);
	}
	
	public Vector3 ScalePosition(Vector3 position, Vector3 scalingPosition)
	{
		return new Vector3(position.x + scalingPosition.x, position.y + scalingPosition.y, position.z + scalingPosition.z);
	}
}