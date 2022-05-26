using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text _HealthCountText;
    float _PlayerHealth;
    float _MaxPlayerHealth = 100;

    private void Start()
    {
        _PlayerHealth = _MaxPlayerHealth;
        _HealthCountText.text = $"{_PlayerHealth}";
        _HealthCountText.color = Color.green;
    }
    private void Update()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        if (_PlayerHealth <= 100 && _PlayerHealth > 70)
        {
            _HealthCountText.color = Color.green;
        }
        else if(_PlayerHealth <= 69 && _PlayerHealth > 30)
        {
            _HealthCountText.color = Color.yellow;
        }
        else if(_PlayerHealth <= 30 && _PlayerHealth >= 0)
        {
            _HealthCountText.color = Color.red;
        }
    }

    public void GetDamage(float damage)
    {
        _PlayerHealth -= damage;
        if(_PlayerHealth < 0)
        {
            _PlayerHealth = 0;
            _HealthCountText.text = $"{_PlayerHealth}";
        }
        else if(_PlayerHealth > 0)
        {
            _HealthCountText.text = $"{_PlayerHealth}";
        }
    }
}
