using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    
    public readonly ReactiveProperty<int> CurrentHealth = new();
    
    private void Awake()
    {
        CurrentHealth.Value = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentOutOfRangeException("Damage cant be less then 0 or equals 0.");
        }
        if (damage < 1)
        {
            damage = 1;
        }
       
        int roundedDamage = (int)Mathf.Round(damage);
        
        CurrentHealth.Value -= roundedDamage;
        
        if (CurrentHealth.Value <= 0)
        {
            KillPlayer();
        }
        else
        {
            Debug.Log($"Took damage = {roundedDamage}, current health = {CurrentHealth.Value}");
        }
    }
    
    private void KillPlayer()
    {
        Debug.Log("Player is dead.");
        
        CurrentHealth.Value = 0;
    }
}