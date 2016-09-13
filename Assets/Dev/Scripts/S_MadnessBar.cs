using UnityEngine;
using System.Collections;

public class S_MadnessBar : MonoBehaviour
{
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    void Start()
    {
        guiStyle = new GUIStyle();
    }

    void OnGUI()
    {
        //DialogBox( new Vector2( 0.25f, 0.75f ), new Vector2( 0.5f, 0.2f ), "Porn everywhere !", 0.019f );
    }

    private void DialogBox(Vector2 _pos, Vector2 _size, string _text, float _textsize)
    {
        Rect _rect = new Rect( _pos.x * Screen.width, _pos.y * Screen.height, _size.x * Screen.width, _size.y * Screen.height);

        GUI.color = new Color( 1, 1, 1, 0.85f );
        GUI.DrawTexture( _rect, progressBarEmpty );

        GUI.color = Color.white;
        float lenght = new Vector2( Screen.height, Screen.width ).magnitude;
        guiStyle.fontSize = (int)(lenght * _textsize);
        GUI.Label( new Rect(_rect.x * 1.05f, _rect.y * 1.05f, _rect.width * 0.9f, _rect.height * 0.9f), _text, guiStyle );
    }

    private void DrawTexture()
    {

    }

    private GUIStyle guiStyle;
    private Vector2 pos = new Vector2(20,40);
    private Vector2 size = new Vector2(10,10);
}
