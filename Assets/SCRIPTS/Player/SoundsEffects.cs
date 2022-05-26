using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour
{
    [SerializeField] AudioSource _GetDamage;
    [SerializeField] AudioSource _PlayerSteps;
    [SerializeField] AudioSource _TakeAmmoBox;
    public void GetDamageSound()
    {
        _GetDamage.Play();
    }
    public void OnPlayerSteps()
    {
        _PlayerSteps.Play();
    }
    public void OffPlayerSteps()
    {
        _PlayerSteps.Stop();
    }
    public void TakeAmmoBox()
    {
        _TakeAmmoBox.Play();
    }
}
