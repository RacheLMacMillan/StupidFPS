using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    
    [SerializeField] private PlayerHealthView _playerHealthView;
    
    public readonly ReactiveProperty<int> CurrentHealth = new();
    
    private void Awake()
    {
        CurrentHealth.Value = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        int roundedDamage = RoundValuable(damage);
    
        if (CurrentHealth.Value <= 0)
        {
            throw new UnityException("You're already dead.");
        }
        else if ((CurrentHealth.Value - roundedDamage) <= 0)
        {
            CurrentHealth.Value = 0;
            
            KillPlayer();
        }
        else
        {
            CurrentHealth.Value -= roundedDamage;
            
            Debug.Log($"Took damage = {roundedDamage}, current health = {CurrentHealth.Value}.");
        }
        
        _playerHealthView.UpdateUI(CurrentHealth.Value, MaxHealth);
    }
    
    public void TakeHealth(float health)
    {
        int roundedHealth = RoundValuable(health);
        
        if (CurrentHealth.Value <= 0)
        {
            throw new UnityException("You're already dead.");
        }
        else if ((CurrentHealth.Value + roundedHealth) >= MaxHealth)
        {
            CurrentHealth.Value = MaxHealth;
            
            Debug.Log($"Enough for healing. You took a health = {roundedHealth}, current health = above the gods.");
        }
        else
        {
            CurrentHealth.Value += roundedHealth;
        
            Debug.Log($"You took a health = {roundedHealth}, current health = {CurrentHealth.Value}.");
        }
        
        _playerHealthView.UpdateUI(CurrentHealth.Value, MaxHealth);
    }
    
    public void ReviewPlayer()
    {
        CurrentHealth.Value = MaxHealth;
            
        _playerHealthView.UpdateUI(CurrentHealth.Value, MaxHealth);
    }
    
    private void KillPlayer()
    {
        Debug.Log("Player is dead.");
    }
    
    private int RoundValuable(float valuable)
    {
        if (valuable <= 0)
        {
            throw new ArgumentOutOfRangeException("Valuable cant be less then 0 or equals 0.");
        }
        if (valuable < 1)
        {
            valuable = 1;
        }
    
        return (int)Mathf.Round(valuable);
    }
}