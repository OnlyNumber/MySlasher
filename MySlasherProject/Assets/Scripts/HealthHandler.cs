using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [field: SerializeField]
    public int MaxHealth { get; private set; }

    private int _currentHealth;

    public System.Action<int> OnHealthChange;

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            
            _currentHealth = value;

            if(_currentHealth > MaxHealth)
            {
                _currentHealth = MaxHealth;
            }

            OnHealthChange?.Invoke(_currentHealth);

        }

    }

    private void Start()
    {
        //OnHealthChange += (() => Debug.Log(""));
    }

    public void ChangeHealth(int healthChange)
    {
        CurrentHealth += healthChange;
    }

    public void Die()
    {

    }


}
