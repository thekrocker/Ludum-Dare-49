using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    public float maxHealth;


    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }
}
