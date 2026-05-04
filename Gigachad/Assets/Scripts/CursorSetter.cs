using UnityEngine;

public class CursorSetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Texture2D mouseTexture;
    void Start()
    {
        Cursor.SetCursor(mouseTexture, new Vector2(0,0), CursorMode.ForceSoftware);
    }
}
