using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class RankController : MonoBehaviour
{
    private BattleController m_BattleController;
    [SerializeField]private List<GameObject> m_PlayersRankGO;


    private void Awake()
    {
        m_BattleController = BattleController.Instance;
    }

    void Start()
    {
        UpdateRank();
    }

    private void Update()
    {
        UpdateRank();
    }

    
    void UpdateRank()
    {
        for (int i = 0; i < m_PlayersRankGO.Count; i++)
        {
            string name = m_BattleController.playersGO[i].GetComponent<PlayerController>().name;
            for (int j = 0; j < 3; j++)
            {
                if (m_PlayersRankGO[j].name == name)
                {
                    m_PlayersRankGO[j].transform.SetSiblingIndex(i);
                    
                    TMP_Text rankText = m_PlayersRankGO[j].GetComponentInChildren<TMP_Text>();
                    rankText.text = (i+1).ToString();
                }
            }
        }
    }
    
}
