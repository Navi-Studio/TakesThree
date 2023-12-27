using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSpeakController : MonoBehaviour
{
    public AudioSource audioSource;
    private BattleController m_BattleController;
    public List<AudioClip> audios = new List<AudioClip>();
    private List<AudioClip> m_TempAudios = new List<AudioClip>();


    void Start()
    {
        m_BattleController = BattleController.Instance;
        // deep copy
        for (int i = 0; i < audios.Count; i++)
        {
            m_TempAudios.Add(audios[i]);
        }
        StartCoroutine(Speech());
    }

    public AudioClip getAudioClip()
    {
        int index = Random.Range(0, m_TempAudios.Count);
        AudioClip audioClip = m_TempAudios[index];
        m_TempAudios.RemoveAt(index);
        return audioClip;
    }
    
    IEnumerator Speech()
    {
        while (!m_BattleController.isGameOver)
        {

            // float random = Random.Range(0f, 12f);
            // if (random == 1)
            // {
            //
            // }
            // else if(random == 2)
            // {
            //     // TTS
            //     // TTSBuilder builder = new BasicTTSBuilder();
            //     // AzureSpeech.Instance.TurnTextToSpeech(builder.build("大家好，欢迎来到今天的赛事"));
            // }
            // else
            // {
            yield return null;
            if (m_BattleController.isGameStart)
            {
                yield return new WaitForSeconds(0.5f);
                audioSource.clip = getAudioClip();
                audioSource.Play();
                while (audioSource.isPlaying && !m_BattleController.isGameOver)
                {
                    yield return null;
                }
            }

            // }
            

        }
    }
    
}
