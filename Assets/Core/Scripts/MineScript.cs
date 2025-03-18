using System;
using System.Collections;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _secondsForWaiting;
    
    private IDamageable _damageable;

    private void OnTriggerEnter(Collider other)
    {
        _damageable = other.GetComponent<IDamageable>();
        
        if (_damageable == null)
        {
            throw new NullReferenceException();
        }
        
        StartCoroutine(ActivateMine());
    }

    private void OnTriggerExit(Collider other)
    {
        _damageable = null;
    }

    private IEnumerator ActivateMine()
    {
        transform.position = new Vector3
        (
            transform.position.x, 
            transform.position.y + 1f, 
            transform.position.z
        );
        
        yield return new WaitForSeconds(_secondsForWaiting);
        
        _damageable.TakeDamage(_damage);
    }
}