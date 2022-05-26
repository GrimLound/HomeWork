using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMove : MonoBehaviour
{
    private void Update()
    {
        PistolMoves();
    }
    void PistolMoves()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetTrigger("Move");           
        }
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetTrigger("StopMove");
        }
    }
}
