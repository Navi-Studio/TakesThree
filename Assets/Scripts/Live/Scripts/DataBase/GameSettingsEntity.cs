using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class GameSettingsEntity : Singleton<GameSettingsEntity>
{
    // 目光跟随模式
    public int LookTargetMode { get; set; } // 0:鼠标 1:摄像头
    // 语言-声源
    public string Speaker { get; set; }
    // ChatGPT API
    public string ChatGPTAPI { get; set; }
    // Azure API
    public string AzureAPI { get; set; }
    // APISpace API
    public string APISpaceAPI { get; set; }
    // 人设
    public string Persona { get; set; }

    private GameSettingsEntity()
    {
        // // 从json文件中读取游戏设置
        // string readData;
        // string fileUrl = Application.persistentDataPath + "\\GameSettings.json";
        // if(File.Exists(fileUrl)){
        //     using (StreamReader sr = File.OpenText(fileUrl))
        //     {
        //         readData = sr.ReadToEnd();
        //         sr.Close();
        //     }
        //     // Debug.Log(readData);
        //
        //     string[] keys = { "LookTargetMode", "Speaker", "ChatGPTAPI", "AzureAPI", "APISpaceAPI", "Persona" };
        //     int[] start_position = new int[6];
        //     for (int i = 0; i < keys.Length; i++)
        //     {
        //         start_position[i] = readData.IndexOf(keys[i]) + keys[i].Length + 2;
        //     }
        //     this.LookTargetMode = int.Parse(readData.Substring(start_position[0], 1));
        //     this.Speaker = readData.Substring(start_position[1] + 1, readData.IndexOf("\"", start_position[1] + 1) - start_position[1] - 1);
        //     this.ChatGPTAPI = readData.Substring(start_position[2] + 1, readData.IndexOf("\"", start_position[2] + 1) - start_position[2] - 1);
        //     this.AzureAPI = readData.Substring(start_position[3] + 1, readData.IndexOf("\"", start_position[3] + 1) - start_position[3] - 1);
        //     this.APISpaceAPI = readData.Substring(start_position[4] + 1, readData.IndexOf("\"", start_position[4] + 1) - start_position[4] - 1);
        //     this.Persona = readData.Substring(start_position[5] + 1, readData.IndexOf("\"", start_position[5] + 1) - start_position[5] - 1);
        //     // Debug.Log(this.LookTargetMode + "&" + this.Speaker + "&" + this.ChatGPTAPI + "&" + this.AzureAPI + "&" + this.APISpaceAPI + ".");
        // }
        // else{
            this.LookTargetMode = 0;
            this.Speaker = "zh-CN-XiaoyiNeural";
            this.ChatGPTAPI = " ";
            this.AzureAPI = " ";
            this.APISpaceAPI = " ";
            this.Persona = "1.请你扮演一名跑步比赛的解说员。2.你的性格是傲娇。3.我会告诉你比赛的情况。4.字数限制在80字以内。5.可以阴阳怪气地嘲讽落后的选手。6.参赛选手有易易，米米，讯讯。";
            // string js = JsonConvert.SerializeObject(this);
            // using (StreamWriter sw = new StreamWriter(fileUrl))
            // {
            //     sw.Write(js);
            //     sw.Close();
            //     sw.Dispose();
            // }
        // }
    }
}
