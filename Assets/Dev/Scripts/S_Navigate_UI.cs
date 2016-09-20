using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_Navigate_UI : MonoBehaviour
{
    void Start()
    {
        m_buttonList = GetComponentsInChildren<Button>();

        Select( 0 );
    }
    

	void OnEnable ()
    {
        Select( 0 );
    }

    private void Select(int _id)
    {
        if (m_buttonList != null)
        {
            if( _id < 0 )
                _id = m_buttonList.Length - 1;
            else
            if( _id >= m_buttonList.Length )
                _id = 0;

            m_currentId = _id;

            m_buttonList[ m_currentId ].Select();
        }
    }

    private int m_currentId;
    private Button[] m_buttonList;
}
