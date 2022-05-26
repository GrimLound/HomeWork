using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] AudioSource open;
    [SerializeField] AudioSource close;
    [SerializeField] GameObject _DoorOpened;
    bool IsOpened;
    Animator _OpenDoor;

    private void Start()
    {
        IsOpened = false;
        _OpenDoor = _DoorOpened.GetComponent<Animator>();
    }

    public void OpenDoors()
    {       
        if(IsOpened == false)
        {
            close.Stop();
            open.Play();
        }
        else if(IsOpened == true)
        {
            open.Stop();
            close.Play();
        }
        IsOpened = !IsOpened;
        _OpenDoor.SetBool("IsOpened", IsOpened);
    }
}
