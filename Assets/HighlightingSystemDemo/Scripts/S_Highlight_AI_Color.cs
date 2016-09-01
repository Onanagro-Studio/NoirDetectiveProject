using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Highlight_AI_Color : MonoBehaviour {


    public GameObject m_SpriteLeft, m_SpriteRight;
    public Color HighlightColor = Color.black;
    public bool IsHighlighted = false;

    void Awake()
    {
        m_highlightRight = m_SpriteRight.AddComponent<Highlighter>();
        m_highlightLeft = m_SpriteLeft.AddComponent<Highlighter>();

    }

    // Use this for initialization
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

        if( IsHighlighted ) m_highlightLeft.ConstantOnImmediate( HighlightColor );
        else m_highlightLeft.ConstantOffImmediate();
        if( IsHighlighted ) m_highlightRight.ConstantOnImmediate( HighlightColor );
        else m_highlightRight.ConstantOffImmediate();


    }

    private Highlighter m_highlightRight, m_highlightLeft;
}
