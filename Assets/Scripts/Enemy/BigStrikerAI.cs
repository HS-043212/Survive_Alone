using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStrikerAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float ShootRange = 0f;
    public LayerMask layerMask;
    private bool isAttack = false;
    public GameObject projective;
    public Transform projectiveStart;
    private float angle;
    public float coolDown;
    private float time;
    private float hp = 1800;
    private Score score;
    private bool isDeath = false;

    void Start()
    {
        score = FindObjectOfType<Score>();
        player = GameObject.Find("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        time = coolDown;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        time += Time.deltaTime;

        Vector3 dir = player.position - transform.position;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, dir.normalized, ShootRange, layerMask);
        //Debug.DrawRay(transform.position, dir.normalized * ShootRange, Color.red, 0.1f);

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                attack();
            }
            else
            {
                isAttack = false;
            }
        }
        else
        {
            isAttack = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isAttack)
        {
            moveCharacter(movement);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= collision.gameObject.GetComponent<Bulletcontrolll>().Damage;

            if (hp <= 0 && !isDeath)
            {
                isDeath = true;

                score.scorePoint = score.scorePoint + 1800;

                Destroy(gameObject);
            }
        }
    }
    void moveCharacter(Vector2 diraction)
    {
        rb.MovePosition((Vector2)transform.position + (diraction * moveSpeed * Time.deltaTime));
    }

    void attack()
    {
        isAttack = true;
        if (time >= coolDown)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projective, projectiveStart.position, Quaternion.AngleAxis(angle, Vector3.forward)).transform.rotation = rotation;
            time = 0f;
        }
    }
}