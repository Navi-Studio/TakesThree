using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(GameSettingsEntity.Instance.AzureAPI) &&
            !string.IsNullOrEmpty(GameSettingsEntity.Instance.ChatGPTAPI))
        {
            ChatScript chatScript = GameObject.FindGameObjectWithTag("LM").GetComponent<ChatScript>();
            // chatScript.SendData("跑步比赛即将开始，直接给我开场稿。");
        }
    }

}
