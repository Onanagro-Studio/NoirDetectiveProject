using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_SliderText : MonoBehaviour {

    public Slider m_slider;
    private Text m_text;

	// Use this for initialization
	void Start () {
        m_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int value = (int)(m_slider.value * 100);
        m_text.text = value.ToString();
	}
}
