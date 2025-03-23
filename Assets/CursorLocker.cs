using UnityEngine;

public class CursorLocker : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void LockCursor()
    {
        Debug.Log("Cursor locked.");
        
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void UnlockCursor()
    {
        Debug.Log("Cursor unlocked.");
    
        Cursor.lockState = CursorLockMode.None;
    }
}