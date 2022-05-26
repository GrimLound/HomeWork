using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    float _damage = 15;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<PlayerHealth>())
        {
            collision.transform.GetComponent<PlayerHealth>().GetDamage(_damage);
            collision.transform.GetComponent<SoundsEffects>().GetDamageSound();
        }
    }
}
