using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponDataSO _weaponData;
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected Transform _shellEjectPosition;

    public WeaponDataSO WeaponData => _weaponData;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting;
    protected bool _isShooting;
    protected bool _delayCoroutine = false;

    #region Ammo관련코드
    protected int _ammo;
    public int Ammo
    {
        get { return _ammo; }
        set
        {
            _ammo = Mathf.Clamp(value, 0, _weaponData.ammoCapacity);
        }
    }
    public bool AmmoFull => Ammo == _weaponData.ammoCapacity;
    public int EmptyBullet => _weaponData.ammoCapacity - _ammo;
    #endregion

    private void Awake()
    {
        _ammo = _weaponData.ammoCapacity;
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (_isShooting && _delayCoroutine == false)
        {
            if (Ammo > 0)
            {
                OnShoot?.Invoke();
                for (int i = 0; i < _weaponData.bulletCount; i++)
                {
                    ShootBullet();

                }
            }
            else
            {
                _isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }
            FinishOneShooting();
        }
    }

    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (_weaponData.autoFire == false)
        {
            _isShooting = false;
        }
    }

    private IEnumerator DelayNextShootCoroutine()
    {
        _delayCoroutine = true;
        yield return new WaitForSeconds(_weaponData.weaponDelay);
        _delayCoroutine = false;
    }

    private void ShootBullet()
    {
        Debug.Log("발사");
    }

    public void TryShooting()
    {
        _isShooting = true;
    }

    public void StopShooting()
    {
        _isShooting = false;
        OnStopShooting?.Invoke();
    }
}
