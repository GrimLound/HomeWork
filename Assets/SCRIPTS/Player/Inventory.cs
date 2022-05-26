using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public float _PistolAmmo = 18;
    float _MaxPistolAmmo = 90;
    [SerializeField] Text _PistolAmmoText;
    [SerializeField] GameObject _Pistol;

    private void Start()
    {
        _PistolAmmoText.text = $"{_PistolAmmo}";
    }
   public void TakeAmmo(float ammo)
    {
        _PistolAmmo += ammo;
        if(_PistolAmmo > _MaxPistolAmmo)
        {
            _PistolAmmo = _MaxPistolAmmo;
            _PistolAmmoText.text = $"{_PistolAmmo}";
        }
        else if(_PistolAmmo <= _MaxPistolAmmo)
        {
            _PistolAmmoText.text = $"{_PistolAmmo}";
        }
    }
    public void ReloadPistol(ref float ammo, float maxAmmo)
    {
        if (_PistolAmmo != 0)
        {
            if (_PistolAmmo >= (maxAmmo - ammo))
            {
                _PistolAmmo -= (maxAmmo - ammo);
                ammo = maxAmmo;
                _PistolAmmoText.text = $"{_PistolAmmo}";
            }
            else if (_PistolAmmo < (maxAmmo - ammo))
            {
                ammo += _PistolAmmo;
                _PistolAmmo = 0;
                _PistolAmmoText.text = $"{_PistolAmmo}";
            }
        }
    }
}
