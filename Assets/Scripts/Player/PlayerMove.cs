using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public float hp = 100;
    public Text hpText;

    private float screenShake;

    float walkSpeed = 0.8f;
    float runSpeed = 1.3f;

    public Image bloodScreen;
    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Walk()
    {
        rb.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);
    }
    
    void Run()
    {
        rb.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);
    }

    void Update()
    {
        ProcessInputs();
        hpText.text = $"{hp.ToString("0")}%";
        hpText.color = new Color(1, hp / 100, hp / 100, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StrikerProjective"))
        {            
            hp -= collision.gameObject.GetComponent<StrikerProjective>().Damage;
            screenShake = collision.gameObject.GetComponent<StrikerProjective>().Damage;
            
            CameraNoise.Instance.ShakeCamera(screenShake / 10, 0.03f);
            StartCoroutine(ShowBloodScreen());

            //Debug.Log(collision.gameObject.GetComponent<StrikerProjective>().Damage);
            //Debug.Log(screenShake);

            if (hp <= 0)
            {
                Debug.Log("죽음");
                //Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("ShooterProjective"))
        {
            hp -= collision.gameObject.GetComponent<ShooterProjective>().Damage;
            screenShake = collision.gameObject.GetComponent<ShooterProjective>().Damage;
            
            CameraNoise.Instance.ShakeCamera(screenShake / 10 + 0.3f, 0.03f);
            StartCoroutine(ShowBloodScreen());

            //Debug.Log(collision.gameObject.GetComponent<ShooterProjective>().Damage);
            //Debug.Log(screenShake);

            if (hp <= 0)
            {
                Debug.Log("죽음");
                //Destroy(gameObject);
            }
        }
    }

    IEnumerator ShowBloodScreen()
    {        
        bloodScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.1f, 0.2f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;
    }
}

