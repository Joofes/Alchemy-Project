using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    [Header("Potion Effects")]
    public bool burn;
    public float burnTimer;
    float burnDamage = 2.5f;

    private void FixedUpdate()
    {
        Burn();
    }
    void Burn()
    {
        if (burn)
            health -= burnDamage * Time.deltaTime;
        burnTimer -= Time.deltaTime;
        if (burnTimer >= 0)
            burn = true;
        else
            burn = false;
    }


}

