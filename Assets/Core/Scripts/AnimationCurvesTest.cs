using UnityEngine;

public class AnimationCurvesTest : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private float _height;
    
    private float _expiredTime;
    private float _duration = 1;

    private void Update()
    {
        _expiredTime += Time.deltaTime;
        
        if (_expiredTime > _duration)
        {
            _expiredTime = 0;
        }
        
        float progress = _expiredTime / _duration;
        
        transform.position = new Vector3(0, _yAnimation.Evaluate(progress) * _height, 0);
    }
}