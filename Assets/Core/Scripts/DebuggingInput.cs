using UnityEngine;

public class DebuggingInput : MonoBehaviour
{
    [SerializeField] private InputMap _debuggingMap;
    
    [SerializeField] private CursorLocker _cursorLocker;

    private void Awake()
    {
        GetRequireComponents();
        
        _debuggingMap = new InputMap();
        
        _debuggingMap.Debug.LockCursor.started += context => _cursorLocker.UnlockCursor();
        _debuggingMap.Debug.LockCursor.performed += context => _cursorLocker.LockCursor();      
        _debuggingMap.Debug.LockCursor.canceled += context => _cursorLocker.UnlockCursor();
    }
    
	private void OnEnable() => _debuggingMap.Enable();
	private void OnDisable() => _debuggingMap.Disable();
    
    private void GetRequireComponents()
    {
        _cursorLocker = GetComponent<CursorLocker>();
    }
}