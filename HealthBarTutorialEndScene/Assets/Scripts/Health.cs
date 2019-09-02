using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth, currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField]
    private Transform healthBarTransform;

    public event Action<int, int> OnHealthChanged = delegate { };

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(OnHealthChanged.GetInvocationList().Length <= 1)
        {
            HealthBarManager.instance.SpawnHealthBar(gameObject, healthBarTransform);
        }

        currentHealth -= amount;
        OnHealthChanged(currentHealth, maxHealth);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(25);
        }
    }

}
