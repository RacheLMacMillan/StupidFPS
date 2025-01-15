using System.Collections;
using UnityEngine;

public class JumperFX : MonoBehaviour
{
	[SerializeField] private AnimationCurve _yAnimation;
	[SerializeField] private float _jumpLenght;
	
	public void PlayerAnimation(Transform jumper, float duration)
	{
		StartCoroutine(AnimationPlaying(jumper, duration));
	}
	
	private IEnumerator AnimationPlaying(Transform jumper, float duration)
	{
		float expiredSeconds = 0;
		float progress = 0;
		
		Vector3 startPosition = jumper.position;
		
		while (true)
		{
			expiredSeconds += Time.deltaTime;
			progress = expiredSeconds / duration;
			
			jumper.position = startPosition + new Vector3(0, _yAnimation.Evaluate(progress), 0);
			
			yield return null;
		}
	}
}