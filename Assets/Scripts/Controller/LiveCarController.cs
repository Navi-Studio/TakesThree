using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCarController : MonoBehaviour
{
    private BattleController m_BattleController;

    private bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        m_BattleController = BattleController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float v = m_BattleController.playersGO[0].transform.position.x - transform.position.x;
        if (v > 30f)
        {
            transform.position = new Vector3(m_BattleController.playersGO[0].transform.position.x - 30f,transform.position.y,transform.position.z) ;
            if (isFirst)
            {
                TTSandChatGPTTest();
                isFirst = false;
            }
        }

        PerformCollision();
    }

    
    
    private void PerformCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 6);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Vector3 position = collider.GetComponent<Transform>().position;
                collider.GetComponent<Transform>().position = new Vector3(position.x + 8f, position.y, position.z);
            }
        }
    }
    
    private void TTSandChatGPTTest()
    {
        // TTS
        // TTSBuilder builder = new BasicTTSBuilder();
        // AzureSpeech.Instance.TurnTextToSpeech(builder.build("大家好，欢迎来到今天的赛事"));
        
        // ChatGPT
        // ChatScript chatScript = GameObject.FindGameObjectWithTag("LM").GetComponent<ChatScript>();
        // chatScript.SendData("米米选手现在领先");
    }
    
}
