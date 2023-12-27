using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BPlayerController : PlayerController
{
    
    void Start()
    {
        name = "米米";
        Init();
    }
    
    void Update()
    {
        InputManage(false);
        BaseRun();
        if (Input.GetKeyDown(KeyCode.DownArrow) && spellTimer <= 0)
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
        List<GameObject> playersGO = m_BattleController.playersGO;
        foreach (var playerGO in playersGO)
        {
            if (playerGO.GetComponent<PlayerController>().name != name)
            {
                if (playerGO.transform.position.x > gameObject.transform.position.x)
                {
                    playerGO.transform.position = new Vector3(playerGO.transform.position.x - 4.5f, playerGO.transform.position.y, playerGO.transform.position.z);
                }
                else
                {
                    playerGO.transform.position = new Vector3(playerGO.transform.position.x + 4.5f, playerGO.transform.position.y, playerGO.transform.position.z);
                }
            }
        }
    }
}
