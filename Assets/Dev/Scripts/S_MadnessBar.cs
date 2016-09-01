using UnityEngine;
using System.Collections;

public class S_MadnessBar : MonoBehaviour
{
    public static float progress = 0.0f;

    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    void OnGUI()
    {
        progress = Mathf.Clamp01( progress );

        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x, size.y ), progressBarEmpty );
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x * progress, size.y ), progressBarFull );
    }

    void Update()
    {
        if( progress > 0.0f )
            progress -= 0.005f * Time.deltaTime;
    }
    
    private Vector2 pos = new Vector2(20,40);
    private Vector2 size = new Vector2(250,40);
}
