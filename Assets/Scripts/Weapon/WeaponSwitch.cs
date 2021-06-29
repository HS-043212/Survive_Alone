using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject SMG;
    public GameObject Rifle;
    public GameObject Shotgun;

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

        
        if (Rifle.activeSelf)
        {
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

        else if (Shotgun.activeSelf)
        {
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
        }

        else if (SMG.activeSelf)
        {
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
