using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bulletcontrolll : MonoBehaviour
{
    public float Damage;
    public float speed;
    public float DestroySec = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        KillBullet();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void KillBullet()
    {
        Destroy(this.gameObject, DestroySec);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Damage = Damage / 1.3f;

        speed = speed / 1.5f;
    }
}