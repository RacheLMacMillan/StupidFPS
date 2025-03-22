using UnityEngine;

public class PlayerDasher : MonoBehaviour
{
    public readonly ReactiveProperty<bool> IsDashing = new();

    [SerializeField] private AnimationCurve _dashCurve;

    [SerializeField] private float _height;
    
    private float _expiredTime;
    private float _duration = 1;
    
    public void Dash(Vector2 direction)
    {
        if (Input.GetKey(KeyCode.V))
        {
            IsDashing.Value = true;
        }
    
        if (IsDashing.Value)
        {
            _expiredTime += Time.deltaTime;
        
            if (_expiredTime > _duration)
            {
                _expiredTime = 0;
                
                IsDashing.Value = false;
            }
            
            float progress = _expiredTime / _duration;
            
            transform.position += new Vector3(_dashCurve.Evaluate(progress) * _height, 1, 0);
        }
        
        Debug.Log(IsDashing.Value);
    }
}