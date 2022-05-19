using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
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
        _OpenDoor.SetBool("IsOpened", IsOpened);
        IsOpened = !IsOpened;
    }
}
