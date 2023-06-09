using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public bool IsEnemy { get; set; }
    public Vector3 _hitPoint { get; private set; }

    protected bool _isDead = false;

    [SerializeField]
    protected int _maxHealth;

    protected int _currentHealth;

    public UnityEvent OnGetHit = null;
    public UnityEvent OnDie = null;

    void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer, Vector3 hitPoint, Vector3 normal)
    {
        if (_isDead) return;

        _currentHealth -= damage;

        OnGetHit?.Invoke();

        if(_currentHealth <= 0)
        {
            DeadProcess();
        }
    }

    private void DeadProcess()
    {
        OnDie?.Invoke();
    }
}
