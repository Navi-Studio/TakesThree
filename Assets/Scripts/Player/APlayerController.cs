using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayerController : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        name = "易易";
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        InputManage(true);
        BaseRun();
        if (Input.GetKeyDown(KeyCode.S) && spellTimer <= 0)
        {
            m_Animator.SetTrigger("isSpell");
        }
    }
    
    private void FixedUpdate()
    {
        Timer();
    }
    
    protected override void Spell()
    {
        spellTimer = SPELLCD;
        m_Speed += 2.2f;
        m_StepSize += 0.22f;
    }
    
    protected override void SpellEnd()
    {
        m_Speed -= 2.2f;
        m_StepSize -= 0.22f;
    }

}
