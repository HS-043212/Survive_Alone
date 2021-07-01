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

    private bool use = false;

    private void Start()
    {
        exit = stop.GetComponent<Image>();
        explanation = ex.GetComponent<Image>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!use)
            {
                if (!isStop) // 진행중이면
                {
                    stop.SetActive(true);
                    ex.gameObject.SetActive(true);

                    use = true;
                    exit.DOFade(1f, 0.5f);
                    ex.DOFade(1f, 0.5f).OnComplete(() =>
                    {
                        Time.timeScale = 0;
                        use = false;
                    });
                }
                else if (isStop) // 멈추고있으면
                {
                    Time.timeScale = 1;

                    use = true;
                    exit.DOFade(0f, 0.5f);
                    ex.DOFade(0f, 0.5f).OnComplete(() =>
                    {

                        use = false;
                        stop.SetActive(false);
                        ex.gameObject.SetActive(false);
                    });
                }

            isStop = !isStop;
            }
        }
    }

}
