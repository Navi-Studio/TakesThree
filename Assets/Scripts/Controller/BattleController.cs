using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BattleController : MonoSingleton<BattleController>
{
    [SerializeField]private List<GameObject> m_PlayersGO = new List<GameObject>();

    public List<GameObject> playersGO { get => m_PlayersGO; }

    private GameObject m_FirstPlayer;
    [HideInInspector]public GameObject firstPlayer { get => m_FirstPlayer; }
    private List<GameObject> m_danmu = new List<GameObject>();

    public GameObject textsdanmu;
    public GameObject danmuParent;
    private Vector3 textpositon;
    private Quaternion textrotation;

    public List<String> danmuList = new List<string>();
    [HideInInspector]public bool isGameStart = false;
    [HideInInspector]public bool isGameOver = false;
    public AudioSource audioSource;

    public AudioClip[] startAndEndAudioClips = new AudioClip[5];
    

    void Start()
    {
        InitDanmu();
        textpositon = new Vector3(40, 5, 10);
        textrotation.eulerAngles = new Vector3(0, 0, 0);
        UpdateRank();
        StartCoroutine(GameStart());
        StartCoroutine(RandomDanMu());
    }

    public void InitDanmu()
    {
        danmuList.Add("太精彩了！");
        danmuList.Add("冲冲冲！");
        danmuList.Add("加油啊！");
        danmuList.Add("233333333333333！");
        danmuList.Add("233333333333333！");
        danmuList.Add("芜湖！");
        danmuList.Add("OHHHHHHHHHHHHHHHH！");
        danmuList.Add("OHHHHHHHHHHHHHHHH！");
        danmuList.Add("燃起来了！");
        danmuList.Add("怎么有人不跑啊！");
        danmuList.Add("别摆烂啊");
        danmuList.Add("行不行啊");
        danmuList.Add("假赛假赛");
        danmuList.Add("退钱！");
        danmuList.Add("米米冲冲冲！");
        danmuList.Add("讯讯最棒！");
        danmuList.Add("易易老婆！");
    }

    void Update()
    {
        UpdateRank();
    }

    public void UpdateRank()
    {
        for(int i=0;i<m_PlayersGO.Count-1; i++)
        {
            if(m_PlayersGO[i].transform.position.x < m_PlayersGO[i + 1].transform.position.x)
            {
                var player = m_PlayersGO[i];
                m_PlayersGO[i] = m_PlayersGO[i + 1];
                m_PlayersGO[i + 1] = player;
                createDanMuEntity(m_PlayersGO[i].GetComponent<PlayerController>().name,true);
            }
        }

        // update No.1
        m_FirstPlayer = m_PlayersGO[0];
    }

    public void createDanMuEntity(string name, bool isName = false)
    {
        // m_danmu = (GameObject)(Instantiate(textsdanmu, textpositon, textrotation));
        GameObject _danmu = GameObject.Instantiate(textsdanmu, danmuParent.transform);
        m_danmu.Add(_danmu);
        if (_danmu != null)
        {
            if (isName)
            {
                _danmu.GetComponent<TMP_Text>().text = name + "加油！";
            }
            else
            {
                _danmu.GetComponent<TMP_Text>().text = name;
            }

            _danmu.transform.GetComponent<RectTransform>().position = new Vector3(3000,
                _danmu.transform.GetComponent<RectTransform>().position.y + Random.Range(-450f, 450f),
                _danmu.transform.GetComponent<RectTransform>().position.z);
            StartCoroutine(DestroyIE(_danmu));
            DOTween.To(() => _danmu.GetComponent<RectTransform>().position.x, x => _danmu.transform.GetComponent<RectTransform>().position = new Vector3(x, _danmu.transform.GetComponent<RectTransform>().position.y, _danmu.transform.GetComponent<RectTransform>().position.z), -2000f, 5f)
                 .SetEase(Ease.Linear).OnComplete(() => {
                     if (_danmu != null)
                     {
                         m_danmu.Remove(_danmu);
                         Destroy(_danmu);
                     }
                });
        }
    }
    
    IEnumerator DestroyIE(GameObject _danmu)
    {
        yield return new WaitForSeconds(6f);
        if (_danmu != null)
        {
            m_danmu.Remove(_danmu);
            Destroy(_danmu);
        }
    }
    
    IEnumerator RandomDanMu()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (isGameStart)
            {
                int random = Random.Range(0, danmuList.Count);
                createDanMuEntity(danmuList[random]);
            }
        }
    }
    
    IEnumerator GameStart()
    {
        for (int i = 0; i < playersGO.Count; i++)
        {
            playersGO[i].GetComponent<Animator>().SetBool("isRun",false);
            playersGO[i].GetComponent<Animator>().SetBool("isWin",true);
        }
        audioSource.clip = startAndEndAudioClips[0];
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    
        isGameStart = true;
        for (int i = 0; i < playersGO.Count; i++)
        {
            playersGO[i].GetComponent<PlayerController>().isActive = true;
            playersGO[i].GetComponent<Animator>().SetBool("isRun",true);
            playersGO[i].GetComponent<Animator>().SetBool("isWin",false);
        }
        yield return null;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            audioSource.Stop();
            audioSource.clip = null;
            isGameOver = true;
            isGameStart = false;
        
            for (int i = 0; i < playersGO.Count; i++)
            {
                // playersGO[i].GetComponent<PlayerController>().isActive = false;
                if (i == 0)
                {
                    playersGO[i].GetComponent<PlayerController>().m_Animator.SetBool("isWin",true);
                    int index = 0;
                    switch (playersGO[i].GetComponent<PlayerController>().name)
                    {
                        case "米米": index = 1; break;
                        case "讯讯": index = 2; break;
                        case "易易": index = 3; break;
                    }

                    audioSource.clip = startAndEndAudioClips[index];
                }
                else
                {
                    playersGO[i].GetComponent<PlayerController>().m_Animator.SetBool("isLose",true);
                }
                playersGO[i].GetComponent<PlayerController>().m_Animator.SetBool("isRun",false);
            }
        
            
            // // ChatGPT
            // ChatScript chatScript = GameObject.FindGameObjectWithTag("LM").GetComponent<ChatScript>();
            // chatScript.SendData("比赛结束了");
        
            // NewGameEvent();
            audioSource.Play();
            StartCoroutine(NewGameEvent());
        }
    }

    private IEnumerator NewGameEvent()
    {
        yield return new WaitForSeconds(4.7f);
        audioSource.clip = startAndEndAudioClips[4];
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("GameStart");
        string currentSceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(UnloadSceneAsync(currentSceneName));
    }
    
    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
        yield return null;
    }
}
