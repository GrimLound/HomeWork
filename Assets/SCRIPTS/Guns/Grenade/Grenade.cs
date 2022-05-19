using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    bool _detonated = false;
    private void Start()
    {
        StartCoroutine(Detonated());
    }
    IEnumerator Detonated()
    {
        yield return new WaitForSeconds(3);
        GetComponent<SphereCollider>().radius = 15f;
        GetComponent<SphereCollider>().isTrigger = true;
        _detonated = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if(_detonated)
        {
            if(other.gameObject.tag != "Plane")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
