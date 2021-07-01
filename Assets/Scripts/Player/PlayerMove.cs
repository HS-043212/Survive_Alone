using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    public float hp = 100;
    public Text hpText;
    private bool Recovering = false;

    private float screenShake;

    float walkSpeed = 0.8f;
    float runSpeed = 1.3f;

    public Image bloodScreen;
    public Image deadScreen;
    private bool isDead = false;

    public AudioSource audioSource;
    public AudioClip deadSound;
    public AudioClip strikerHittingSound;
    public AudioClip shooterHittingSound;
    public AudioClip BGM;

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

        if(hp < 20 && hp >= 1 && !Recovering)
        {
            Recovering = true;
            StartCoroutine(HpRecovery());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StrikerProjective") && !isDead)
        {            
            hp -= collision.gameObject.GetComponent<StrikerProjective>().Damage;
            screenShake = collision.gameObject.GetComponent<StrikerProjective>().Damage;

            audioSource.PlayOneShot(strikerHittingSound, 0.8f);

            CameraNoise.Instance.ShakeCamera(screenShake / 10, 0.03f);
            StartCoroutine(ShowBloodScreen());

            //Debug.Log(collision.gameObject.GetComponent<StrikerProjective>().Damage);
            //Debug.Log(screenShake);

            if (hp <= 0)
            {
                isDead = true;
                hp += -hp;

                //Debug.Log("죽음");

                walkSpeed = 0;
                runSpeed = 0;

                audioSource.PlayOneShot(deadSound, 1f);
                StartCoroutine(ShowDarkScreen());
            }
        }

        if (collision.gameObject.CompareTag("ShooterProjective") && !isDead)
        {
            hp -= collision.gameObject.GetComponent<ShooterProjective>().Damage;
            screenShake = collision.gameObject.GetComponent<ShooterProjective>().Damage;

            audioSource.PlayOneShot(shooterHittingSound, 0.8f);

            CameraNoise.Instance.ShakeCamera(screenShake / 10 + 0.3f, 0.03f);
            StartCoroutine(ShowBloodScreen());

            //Debug.Log(collision.gameObject.GetComponent<ShooterProjective>().Damage);
            //Debug.Log(screenShake);

            if (hp <= 0)
            {
                isDead = true;
                hp += -hp;

                //Debug.Log("죽음");

                walkSpeed = 0;
                runSpeed = 0;

                audioSource.PlayOneShot(deadSound, 1f);
                StartCoroutine(ShowDarkScreen());
            }
        }
    }

    IEnumerator ShowDarkScreen()
    {
        for (float i = 0; i < 1.1; i += 0.00625f)
        {
            yield return new WaitForSeconds(0.04f);
            deadScreen.color = new Color(0, 0, 0, i * 2);
            audioSource.volume -= i; // 음악 페이드아웃
        }
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator ShowBloodScreen()
    {        
        bloodScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.1f, 0.2f));
        yield return new WaitForSeconds(0.1f);
        bloodScreen.color = Color.clear;
    }

    IEnumerator HpRecovery()
    {
        yield return new WaitForSeconds(4f);
        hp += 1;

        Recovering = false;
    }
}

