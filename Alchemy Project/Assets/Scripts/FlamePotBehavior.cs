using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePotBehavior : MonoBehaviour
{
    //once slow, break, check radius for enemys and trigger a burn function

    Rigidbody2D rb;

    public float radius;

    public LayerMask enemyLayer;

    public float effectDuration = 3f;

    //var fix for instant break
    float timer = 0.1f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 1f && timer <= 0)
        {
            Break();
        }
        timer -= Time.deltaTime;
    }
    void Break()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        foreach(Collider2D col in colliders)
        {
            col.gameObject.GetComponent<Enemy>().burnTimer = effectDuration;
        }
        DestroyImmediate(gameObject);
    }

    void OnDrawGizmos()
    {
        // Set the color of the debug circle
        Gizmos.color = Color.red;

        // Draw a wireframe circle to visualize the detection radius
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
