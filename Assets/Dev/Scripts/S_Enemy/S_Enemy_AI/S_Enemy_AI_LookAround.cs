using UnityEngine;
using System.Collections;

public class S_Enemy_AI_LookAround : MonoBehaviour
{
    public float RandomLookTime_Min = 3.0f;
    public float RandomLookTime_Max = 8.0f;

    void Start ()
    {
        m_enemy_AI = GetComponent<S_Enemy_AI>();
    }
    
    void Update ()
    {
        if ( m_enemy_AI.m_state == EnemyAction.LookAround )
        {

        }
    }
    
    public void Start_LookAround()
    {

    }

    private S_Enemy_AI m_enemy_AI;
}
