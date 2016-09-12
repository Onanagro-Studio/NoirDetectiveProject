using UnityEngine;
using System.Collections;

public class S_MadnessBar : MonoBehaviour
{
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    void OnGUI()
    {
        S_Charact_Madness.Madness = Mathf.Clamp01( S_Charact_Madness.Madness );

        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x, size.y ), progressBarEmpty );
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x * S_Charact_Madness.Madness, size.y ), progressBarFull );
    }
    
    private Vector2 pos = new Vector2(20,40);
    private Vector2 size = new Vector2(250,40);
}
