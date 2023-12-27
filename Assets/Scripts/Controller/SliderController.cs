using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public GameObject startGO;
    public GameObject endGO;
    public Slider slider;
    private float m_Length;
    private BattleController m_BattleController;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Length = endGO.transform.position.x - startGO.transform.position.x;
        m_BattleController = BattleController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float length = m_BattleController.playersGO[0].transform.position.x - startGO.transform.position.x;
        slider.value = length / m_Length;
        if (slider.value > 0.95f)
        {
            // TODO Win
            m_BattleController.GameOver();
            slider.value = 1f;
        }
    }
}
