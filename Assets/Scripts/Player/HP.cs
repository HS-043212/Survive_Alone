using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField]
    public Slider hpBar;
    public Slider hpBar1;

    private float maxHp = 100;
    private float curHp;
    float imsi;

    void Start()
    {        
        hpBar.value = (float)curHp / (float)maxHp;
        hpBar1.value = (float)curHp / (float)maxHp;
    }
    
    void Update()
    {       
        hpHandle();

        imsi = (float)curHp / (float)maxHp;
    }

    private void hpHandle()
    {
        curHp = GetComponent<PlayerMove>().hp;

        hpBar.value = Mathf.Lerp(hpBar.value, imsi, Time.deltaTime * 10);
        hpBar.transform.GetChild(0).GetChild(0).GetComponent<Image>().color =
            new Color(1, GetComponent<PlayerMove>().hp / maxHp, GetComponent<PlayerMove>().hp / maxHp, 1);
        hpBar1.value = Mathf.Lerp(hpBar1.value, imsi, Time.deltaTime * 10);
        hpBar1.transform.GetChild(0).GetChild(0).GetComponent<Image>().color =
            new Color(1, GetComponent<PlayerMove>().hp / maxHp, GetComponent<PlayerMove>().hp / maxHp, 1);
    }
}
