using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    public float speed;
    public float size;

    Rigidbody2D rb;

    public bool isFiring;
    float delaytime;

    [SerializeField]
    private GameObject Player;

    private Vector2 mousePos;

    public Bulletcontrolll bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;

    public int damage;

    private int remainAmmo;
    public int remainBullet;
    public float reloadTime = 2.9f;
    public float reloadTime_bulletLeft = 2.2f;
    public float bulletEmpty = 0.3f;

    public AudioSource audioSource;
    public AudioClip fireSound;
    public AudioClip reloadSound;
    public AudioClip reload_bulletLeft_Sound;
    public AudioClip bullet_Empty;

    public Text bulletText;

    WeaponSwitch weaponSwitch;

    public bool isReloading = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainBullet = 31;
        remainAmmo = 150;
        GameObject.FindObjectOfType<WeaponSwitch>();
    }

    IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(reloadTime);
        remainBullet = 30;
        isReloading = false;
    }

    IEnumerator Reload_Routine()
    {
        yield return new WaitForSeconds(reloadTime_bulletLeft);
        remainBullet = 31;
        isReloading = false;
    }

    void Update()
    {        
        bulletText.text = $"{remainBullet.ToString("0")}";
        bulletText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);

        if (remainBullet <= 0)
        {
            isFiring = false;
        }
        if (delaytime > 0)
        {
            delaytime -= Time.deltaTime;
        }
        Shoot();

        UnityEngine.Vector3 mPosition = Input.mousePosition;
        UnityEngine.Vector3 oPosition = transform.position;

        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        UnityEngine.Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, rotateDegree);

        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (Player.transform.localPosition.x > mousePos.x)
        {
            transform.localScale = new Vector2(size, -size);
        }

        if (Player.transform.localPosition.x < mousePos.x)
        {
            transform.localScale = new Vector2(size, size);
        }
    }

    void Shoot()
    {
        if (!isReloading)
        {
            if (remainBullet > 0)
            {
                if (Input.GetMouseButtonDown(0) && delaytime <= 0)
                {
                    delaytime = 0.0857f;
                    isFiring = true;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    isFiring = false;
                }

                if (isFiring)
                {
                    shotCounter -= Time.deltaTime;
                    if (shotCounter <= 0)
                    {
                        audioSource.volume = 0.5f;
                        audioSource.PlayOneShot(fireSound);
                        shotCounter = timeBetweenShots;
                        Bulletcontrolll newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bulletcontrolll;
                        newBullet.speed = bulletSpeed;
                        remainBullet -= 1;

                        CameraNoise.Instance.ShakeCamera(0.8f, 0.02f);
                        
                        if(remainBullet == 0)
                        {
                            audioSource.PlayOneShot(bullet_Empty);
                        }
                    }
                }
                else
                {
                    shotCounter = 0;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) && delaytime <= 0)
                {
                    audioSource.PlayOneShot(bullet_Empty);
                }
            }
        }

        if (remainBullet <= 30)
        {
            if (!isReloading)
            {
                if (remainBullet <= 0 && Input.GetKeyDown("r"))
                {
                    isReloading = true;
                    audioSource.PlayOneShot(reloadSound);
                    StartCoroutine(ReloadRoutine());
                }
                else if (Input.GetKeyDown("r"))
                {
                    isReloading = true;
                    audioSource.PlayOneShot(reload_bulletLeft_Sound);
                    StartCoroutine(Reload_Routine());
                }
            }
        }
    }
}