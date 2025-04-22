using UnityEngine;

public class DebuggingInput : MonoBehaviour
{
    [SerializeField] private InputMap _debuggingMap;
    
    [SerializeField] private CursorLocker _cursorLocker;
    
    [SerializeField] private PlayerHealth _playerHealth;
    
    [SerializeField] private float _damage;
    [SerializeField] private float _health;

    private void Awake()
    {
        GetRequireComponents();
        
        _debuggingMap = new InputMap();
        
        _debuggingMap.Debug.LockCursor.started += context => _cursorLocker.UnlockCursor();
        _debuggingMap.Debug.LockCursor.performed += context => _cursorLocker.UnlockCursor();
        _debuggingMap.Debug.LockCursor.canceled += context => _cursorLocker.LockCursor();
    }
    
	private void OnEnable() => _debuggingMap.Enable();  
	private void OnDisable() => _debuggingMap.Disable();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            _playerHealth.TakeDamage(_damage);
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            _playerHealth.TakeHealth(_health);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _playerHealth.ReviewPlayer();
        }
    }

    private void GetRequireComponents()
    {
        _cursorLocker = GetComponent<CursorLocker>();
    }
}