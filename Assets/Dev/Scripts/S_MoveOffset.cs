using UnityEngine;
using System.Collections;

public class S_MoveOffset : MonoBehaviour {

    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    public Renderer rend;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        rend.material.SetTextureOffset( "_MainTex", new Vector2( offsetX, offsetY ) );
    }
}
