using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D NcursorTexture;
    public bool hotSpotIsCenter = false;
    public Vector2 adjustHotSpot = Vector2.zero;
    private Vector2 hotSpot;

    public void Start()
    {
        StartCoroutine("MyCursor");
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(NcursorTexture, hotSpot, CursorMode.Auto);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        }
    }


    IEnumerator MyCursor()
    {
        yield return new WaitForEndOfFrame();
        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        }
        else
        {
            hotSpot = adjustHotSpot;
        }
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}
