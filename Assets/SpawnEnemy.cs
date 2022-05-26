using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject _Enemy;
    [SerializeField] List<Transform> _SpawnPoints;
    float _SpawnTime = 8;
    float _CurrentTime;
    private void Start()
    {
        foreach (Transform t in _SpawnPoints)
        {
            Instantiate(_Enemy, t.transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {

        if( _CurrentTime > _SpawnTime )
        {
            foreach( Transform t in _SpawnPoints )
            {
                Instantiate(_Enemy, t.transform.position, Quaternion.identity);
            }
            _CurrentTime = 0;
        }
        _CurrentTime += Time.deltaTime;
    }
}
