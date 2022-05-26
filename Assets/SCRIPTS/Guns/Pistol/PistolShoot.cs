using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolShoot : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] AudioSource _ShootSound;
    [SerializeField] AudioSource _NoAmmo;
    [SerializeField] AudioSource _Reload;
    [SerializeField] Camera ShootCamera;
    [SerializeField] ParticleSystem _ShootParticles;
    bool _ReloadOff;
    public Text _AmmoCountText;
    public Image _PistolBulletImage;
    public Image _PistolImage;
    float _Ammo;
    float _MaxAmmo = 9;
    float _MaxDistance = 20;
    float _damage = 35;
    Ray _Ray;
    RaycastHit _Hit;

    private void Start()
    {
        _ReloadOff = true;
        _Ammo = _MaxAmmo;
        _AmmoCountText.text = $"{_Ammo}";        
    } 

    private void Update()
    {
        Shoot();
        Reload();
    }   
    
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && _Ammo > 0)
        {
            _Ammo -= 1;
            _AmmoCountText.text = $"{_Ammo}";
            _ShootParticles.Play();    
            GetComponent<Animator>().SetTrigger("Fire");
            _ShootSound.Play();
            _Ray = ShootCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Physics.Raycast(_Ray, out _Hit, _MaxDistance);
            if(_Hit.transform != null)
            {
                Debug.Log(_Hit.transform.name);
                EnemyDamage(ref _Hit);
            }      
            GetComponent<Animator>().SetTrigger("StopFire");
        }
        else if(Input.GetMouseButtonDown(0) && _Ammo <= 0)
        {
            _NoAmmo.Play();
        }
    }
   
    void Reload()
    {
        if(Input.GetKeyDown(KeyCode.R) && _Ammo < _MaxAmmo && _Player.GetComponent<Inventory>()._PistolAmmo != 0)
        {
            GetComponent<Animator>().SetTrigger("Reload");
            _Reload.Play();
            _Player.GetComponent<Inventory>().ReloadPistol(ref _Ammo, _MaxAmmo);
            _AmmoCountText.text = $"{_Ammo}";
            GetComponent<Animator>().SetBool("ReloadOff", _ReloadOff);
        }
    }

    void EnemyDamage(ref RaycastHit Hit)
    {
        if (Hit.transform.GetComponentInParent<EnemyHealth>())
        {
            Hit.transform.GetComponentInParent<EnemyHealth>().GetDamage(_damage);                  
        }        
    }
}
