using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    GameObject _Target;
    NavMeshAgent _Agent;
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("Detected");
    }
    private void Update()
    {
        if(!_Agent.pathPending)
        {
            _Agent.destination = _Target.transform.position;
        }
    }

    //void EnemyDetected()
    //{
    //    var RotDicertion = transform.position - _Target.transform.position;
    //    var TargetRotation = Quaternion.LookRotation(-RotDicertion.normalized);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, 20 * Time.deltaTime);
    //}
    //void EnemyMove()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, _Target.transform.position, 8 * 0.1f * Time.deltaTime); 
    //}
}
