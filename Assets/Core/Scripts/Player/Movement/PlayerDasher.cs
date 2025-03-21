using UnityEngine;

public class PlayerDasher : MonoBehaviour
{
    [SerializeField] private AnimationCurve _dashCurve;

    [SerializeField] private float _height;
    
    private float _expiredTime;
    private float _duration = 1;
    
    private bool isDashing = false;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            isDashing = true;
        }
    
        if (isDashing)
        {
            _expiredTime += Time.deltaTime;
        
            if (_expiredTime > _duration)
            {
                _expiredTime = 0;
                
                isDashing = false;
            }
            
            float progress = _expiredTime / _duration;
            
            transform.position += new Vector3(_dashCurve.Evaluate(progress) * _height, 1, 0);
        }
        
        Debug.Log(isDashing);
    }
}