using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerProjective : MonoBehaviour
{
    public float Damage;
    public float speed;
    public float destSec;
    public float delayTime;

    bool isProjectiving = false;

    void Start()
    {
        Destroy(gameObject, destSec);
    }

    // Update is called once per frame
    void Update()
    {

        if(!isProjectiving)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * -speed * Time.deltaTime);

        StartCoroutine(shootDelay());
    }
    
    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isProjectiving = true;
    }
}
