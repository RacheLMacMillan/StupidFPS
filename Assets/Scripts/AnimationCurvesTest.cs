using Unity.VisualScripting;
using UnityEngine;

public class AnimationCurvesTest : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _time;
    [SerializeField] private float _duration;
    [SerializeField] private float _multipl;

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        
        if (_time > _duration)
        {
            _time = 0;
        }
        
        float progress = _time / _duration;
        
        Vector3 f = transform.position;
        
        transform.position = new Vector3(f.x, f.y + _curve.Evaluate(progress) * _multipl, f.z);
    }
}