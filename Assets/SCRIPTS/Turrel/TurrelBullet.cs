using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelBullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delete());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(5);
        if(gameObject != null)
        {
            Destroy(gameObject.gameObject);
        }
    }
}
