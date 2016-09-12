using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_HighlightObject : MonoBehaviour {

    public bool isHighlighted = true;
    public Color m_HighlightColor = Color.gray;
    public GameObject m_Object;
    // Use this for initialization
    void Start () {

        m_highlighter = m_Object.AddComponent<Highlighter>();

        if(isHighlighted)
            m_highlighter.ConstantOnImmediate( m_HighlightColor );
    }
	
	// Update is called once per frame
	void Update () {
        if( isHighlighted )
            m_highlighter.ConstantOnImmediate( m_HighlightColor );
    }

    private Highlighter m_highlighter;
}
