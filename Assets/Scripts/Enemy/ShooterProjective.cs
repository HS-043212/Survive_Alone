using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjective : MonoBehaviour
{
    public float Damage;
    public float speed;
    public float destSec;

    void Start()
    {
        Destroy(gameObject, destSec);
    }


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
