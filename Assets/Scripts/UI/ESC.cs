using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ESC : MonoBehaviour
{
    public bool isStop = false;

    public GameObject stop;
    public Image ex;

    Image exit;
    Image explanation;

    private void Start()
    {
        exit = stop.GetComponent<Image>();
        explanation = ex.GetComponent<Image>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isStop) // 진행중이면
            {
                stop.SetActive(true);
                ex.gameObject.SetActive(true);

                StartCoroutine(ShowExitButton());
            }
            else if(isStop) // 멈추고있으면
            {
                StartCoroutine(HideExitButton());

                stop.SetActive(false);
                ex.gameObject.SetActive(false);
            }

            isStop = !isStop;
        }
    }

    IEnumerator ShowExitButton()
    {
        exit.DOFade(1f, 0.5f);
        ex.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 0;
    }

    IEnumerator HideExitButton()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.5f);

        exit.DOFade(0f, 0.5f);
        ex.DOFade(0f, 0.5f);        
    }
}
