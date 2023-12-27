using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerAController : PlayerController
{
    void Start()
    {
        name = "讯讯";
        Init();
        m_Speed = 2.4f;
        StartCoroutine(DoSpell());
    }
    

    void Update()
    {
        BaseRun();
    }
    
    
    IEnumerator DoSpell()
    {
        while (true)
        {
            if (isActive)
            {
                float random = Random.Range(8f, 12f);
                yield return new WaitForSeconds(random);
                m_Animator.SetTrigger("isSpell");
            }
        }
    }
    
    
    
    protected override void Spell()
    {

        List<GameObject> playersGO = m_BattleController.playersGO;
        foreach (var playerGO in playersGO)
        {
            if (playerGO.GetComponent<PlayerController>().name != name)
            {
                playerGO.GetComponent<PlayerController>().isActive = false;
                playerGO.GetComponent<Animator>().enabled = false;
            }
        }
    }
    
    protected override void SpellEnd()
    {
        List<GameObject> playersGO = m_BattleController.playersGO;
        foreach (var playerGO in playersGO)
        {
            if (playerGO.GetComponent<PlayerController>().name != name)
            {
                playerGO.GetComponent<PlayerController>().isActive = true;
                playerGO.GetComponent<Animator>().enabled = true;
            }
        }
    }
    
}
