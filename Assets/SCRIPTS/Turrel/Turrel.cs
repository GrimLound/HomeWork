using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    [SerializeField] Light _DetectionLight;
    [SerializeField] GameObject _Target;
    [SerializeField] GameObject _Bullet;
    [SerializeField] Transform _GunFirst;
    [SerializeField] Transform _GunSecond;
    [SerializeField] float _timeShoot = 1f;
    float _force = 1000;
    Quaternion _DefaultRotation;
    bool detection;


    private void Start()
    {
        _DetectionLight.color = Color.green;
        _DefaultRotation = transform.rotation;
        detection = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detection = true;
            _DetectionLight.color = Color.red;
            StartCoroutine(Shoot());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            detection = false;
            transform.rotation = _DefaultRotation;
            _DetectionLight.color = Color.green;
            StopAllCoroutines();
        }
    }


    private void Update()
    {
        if (detection)
        {
            var RotDicertion = transform.position - _Target.transform.position;
            var TargetRotation = Quaternion.LookRotation(-RotDicertion.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, 20 * Time.deltaTime);
        }
    }


    IEnumerator Shoot()
    {
        GameObject BulletOne = Instantiate(_Bullet, _GunFirst.transform.position, Quaternion.identity);
        BulletOne.GetComponent<Rigidbody>().AddForce(transform.forward * _force);
        yield return new WaitForSeconds(_timeShoot);
        GameObject BulletTwo = Instantiate(_Bullet, _GunSecond.transform.position, Quaternion.identity);
        BulletTwo.GetComponent<Rigidbody>().AddForce(transform.forward * _force);
        yield return new WaitForSeconds(_timeShoot);
        StartCoroutine(Shoot());
    }
}
