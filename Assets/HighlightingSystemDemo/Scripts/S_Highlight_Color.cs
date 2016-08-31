using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Highlight_Color : MonoBehaviour {

    protected Highlighter h;
    public Color m_color;

    void Awake()
    {
        h = gameObject.AddComponent<Highlighter>();
    }

    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
        h.ConstantOn( m_color );
        h.SeeThroughOn();
    }
}
