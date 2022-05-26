using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Image _EnemyHealthText;
    float _EnemyHealth;
    private void Start()
    {
        _EnemyHealth = 100;
        _EnemyHealthText.fillAmount = 1;
    }

    private void Update()
    {
        Die();
    }
    void Die()
    {
        if (_EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GetDamage(float damage)
    {
        _EnemyHealth -= damage;
        damage /= 100;
        _EnemyHealthText.fillAmount -= damage;
    }  
}
