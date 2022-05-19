using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    [SerializeField] AudioSource _ShootSound;
    [SerializeField] Camera ShootCamera;
    bool _IsShooting;
    float _MaxDistance = 20;
    //float _damage = 20;
    Ray _Ray;
    RaycastHit _Hit;

    private void Start()
    {
        _IsShooting = true;
    }


    private void Update()
    {       
        if (_IsShooting)
        {
            StartCoroutine(Shoot());
        }
    }   
    
    IEnumerator Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetTrigger("Fire");
            _ShootSound.Play();
            _Ray = ShootCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Physics.Raycast(_Ray, out _Hit, _MaxDistance);
            if (_Hit.collider != null)
            {
                Debug.Log(_Hit.collider.name);
            }
            _IsShooting = false;
            yield return new WaitForSeconds(0.5f);
            _IsShooting = true;
        }
    }
}
