using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject SMG;
    public GameObject Rifle;
    public GameObject Shotgun;

    Rifle rifle;
    Shotgun shotgun;
    SMG smg;

    public Text rifleText;
    public Text shotgunText;
    public Text smgText;

    public Image rifleSilhouette;
    public Image shotgunSilhouette;
    public Image smgSilhouette;

    private void Awake()
    {
        rifle = FindObjectOfType<Rifle>();
        shotgun = FindObjectOfType<Shotgun>();
        smg = FindObjectOfType<SMG>();     
    }

    void Start()
    {
        Rifle.SetActive(true);
        Shotgun.SetActive(false);
        SMG.SetActive(false);
    }

    void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown("1"))
        {
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            SMG.SetActive(false);
            Rifle.GetComponent<Rifle>().isReloading = false;
        }

        if (Input.GetKeyDown("2"))
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(true);
            SMG.SetActive(false);
            Shotgun.GetComponent<Shotgun>().isReloading = false;
        }

        if (Input.GetKeyDown("3"))
        {
            Rifle.SetActive(false);
            Shotgun.SetActive(false);
            SMG.SetActive(true);
            SMG.GetComponent<SMG>().isReloading = false;

            
        }

        if (Rifle.activeSelf && !Shotgun.activeSelf && !SMG.activeSelf)
        {
            rifleText.text = $"{rifle.remainBullet.ToString("0")}";
            rifleText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);
            rifleSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);

            shotgunText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            shotgunSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            smgText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            smgSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            if (wheelInput > 0)
            {
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                SMG.SetActive(true);
                Rifle.GetComponent<Rifle>().isReloading = false;
            }
            else if (wheelInput < 0)
            {
                Rifle.SetActive(false);
                Shotgun.SetActive(true);
                SMG.SetActive(false);
                Rifle.GetComponent<Rifle>().isReloading = false;
            }            
        }

        else if (Shotgun.activeSelf && !Rifle.activeSelf && !SMG.activeSelf)
        {
            shotgunText.text = $"{shotgun.remainBullet.ToString("0")}";
            shotgunText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);
            shotgunSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);

            rifleText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            rifleSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            smgText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            smgSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            if (wheelInput > 0)
            {
                Rifle.SetActive(true);
                Shotgun.SetActive(false);
                SMG.SetActive(false);
                Shotgun.GetComponent<Shotgun>().isReloading = false;
            }
            else if (wheelInput < 0)
            {
                Rifle.SetActive(false);
                Shotgun.SetActive(false);
                SMG.SetActive(true);
                Shotgun.GetComponent<Shotgun>().isReloading = false;
            }

            shotgunText.text = $"{shotgun.remainBullet.ToString("0")}";
            shotgunText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);
        }

        else if (SMG.activeSelf && !Rifle.activeSelf && !Shotgun.activeSelf)
        {
            smgText.text = $"{smg.remainBullet.ToString("0")}";
            smgText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);
            smgSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 1);

            rifleText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            rifleSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            shotgunText.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0);
            shotgunSilhouette.color = new Color(0.7450981f, 0.7450981f, 0.7450981f, 0.3f);

            if (wheelInput > 0)
            {
                Rifle.SetActive(false);
                Shotgun.SetActive(true);
                SMG.SetActive(false);
                SMG.GetComponent<SMG>().isReloading = false;
            }
            else if (wheelInput < 0)
            {
                Rifle.SetActive(true);
                Shotgun.SetActive(false);
                SMG.SetActive(false);
                SMG.GetComponent<SMG>().isReloading = false;
            }
        }
    }
}