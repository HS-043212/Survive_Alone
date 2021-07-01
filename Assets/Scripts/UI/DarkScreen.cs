using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    public Image darkScreen;

    void Start()
    {
        StartCoroutine(ShowDarkScreen());
    }

    IEnumerator ShowDarkScreen()
    {
        for (float i = 1; i > 0; i -= 0.05f)
        {
            darkScreen.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.00625f);
        }
    }
}
