using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float t = 0;
    public float Amp = 0.1f;
    public float Freq = 2;
    public float Offset = 0;
    public Vector3 StartPos;
    float _Ammo = 15;
    private void Start()

    {
        StartPos = transform.position;
    }

    void Move()
    {
        t = t + Time.deltaTime;
        Offset = Amp * Mathf.Sin(t * Freq);
        transform.position = StartPos + new Vector3(0, Offset, 0);
        transform.Rotate(0, 0.3f, 0);
    }
    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Inventory>().TakeAmmo(_Ammo);
            other.GetComponent<SoundsEffects>().TakeAmmoBox();
            Destroy(gameObject);
        }
    }
}
