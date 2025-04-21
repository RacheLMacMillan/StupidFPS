using System.Collections;
using UnityEngine;

public class JumpFX : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    
    public void PlayAnimation(Transform jumper, float duration)
    {
        StartCoroutine(AnimationByTime(jumper, duration));
    }
    
    private IEnumerator AnimationByTime(Transform jumper, float duration)
    {
        float expiredSeconds = 0;
        float progress = 0;
        
        Vector3 startPosition = jumper.position;
        
        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;
            
            jumper.position = startPosition + new Vector3(0, _yAnimation.Evaluate(progress), 0);
            
            yield return null;
        }
    }
}