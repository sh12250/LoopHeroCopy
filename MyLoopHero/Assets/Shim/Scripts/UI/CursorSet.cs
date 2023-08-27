using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSet : MonoBehaviour
{
    private Texture2D cursorImage;

    private Vector2 cursorPoint;

    private void Awake()
    {
        cursorImage = Resources.Load<Texture2D>("Sprites/UI_Button/s_cursor_0");
        cursorPoint = Vector2.zero;

        Cursor.SetCursor(cursorImage, cursorPoint, CursorMode.ForceSoftware);
    }
}
