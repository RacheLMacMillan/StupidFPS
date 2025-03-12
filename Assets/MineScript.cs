using System;
using System.Collections;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _secondsForWaiting;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        
        if (damageable == null)
        {
            throw new NullReferenceException();
        }
        
        StartCoroutine(ActivateMine(damageable));
    }
    
    private IEnumerator ActivateMine(IDamageable damageable)
    {
        transform.position = new Vector3
        (
            0, 
            Mathf.Lerp(0f, 1f, _secondsForWaiting * Time.deltaTime), 
            0
        );
        
        yield return new WaitForSeconds(_secondsForWaiting);
        
        damageable.TakeDamage(_damage);
    }
}