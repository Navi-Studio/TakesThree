using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public string name;
    protected float m_StepSize = 0.3f;
    protected float m_Speed = 1f;
    [HideInInspector]public Animator m_Animator;
    protected BattleController m_BattleController;
    
    private bool isPlayerLastInput = true;
    
    public bool isActive = true;
    
    public float spellTimer;
    protected static float SPELLCD = 10f;
    public Image Image;



    protected void Timer(){
        if (spellTimer > 0){
            spellTimer -= Time.deltaTime;
            UpdateSpellIcon();
        }
    }

    public void UpdateSpellIcon(){
        Image.fillAmount = 1 - (SPELLCD - spellTimer) / SPELLCD;	// spell icon cd percent
    }
    
    

    protected void Init()
    {
        m_Animator = GetComponent<Animator>();
        m_BattleController = BattleController.Instance;
        spellTimer = SPELLCD;
    }
    
    protected void BaseRun()
    {
        if (isActive && m_BattleController.isGameStart)
        {
            float moveDistance = m_Speed * Time.deltaTime;
            transform.position += Vector3.right * moveDistance;
        }
    }

    protected void InputManage(bool isPlayerA)
    {
        if (isActive && m_BattleController.isGameStart)
        {
            KeyCode keyCodeA = isPlayerA ? KeyCode.A : KeyCode.LeftArrow;
            KeyCode keyCodeB = isPlayerA ? KeyCode.D : KeyCode.RightArrow;

            if (Input.GetKeyDown(keyCodeA) && isPlayerLastInput || Input.GetKeyDown(keyCodeB) && !isPlayerLastInput)
            {
                transform.position += new Vector3(m_StepSize, 0, 0);
                isPlayerLastInput = !isPlayerLastInput;
                m_Speed += 0.01f;
                m_StepSize += 0.0001f;
            }
        }
    }

    protected virtual void Spell()
    {
        
    }
    
    protected virtual void SpellEnd()
    {
        
    }
}
