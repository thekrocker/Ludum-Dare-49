using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;



    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
