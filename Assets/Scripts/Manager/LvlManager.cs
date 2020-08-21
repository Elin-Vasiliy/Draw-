using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public static int CountAnlockedLevel = 1;

    //public Sprite Image;

    public List<GameObject> m_lvlBtns = new List<GameObject>();
    public List<Sprite> m_star;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("CountAnlockedLevel") <= 1)
        {
            CountAnlockedLevel = 1;
        }
        else
        {
            CountAnlockedLevel = PlayerPrefs.GetInt("CountAnlockedLevel");
        }
    }

    private void Start()
    {
        ActiveLvLAnim();
    }

    private void ActiveLvLAnim()
    {
        for (int i = 0; i < m_lvlBtns.Count; i++)
        {
            if (i < CountAnlockedLevel && i < SceneManager.sceneCountInBuildSettings - 1)
            {
                for (int j = 0; j < 3; j++)
                {
                    m_lvlBtns[i].gameObject.transform.GetChild(j).gameObject.SetActive(true);
                }

                if (PlayerPrefs.GetInt($"{i + 1}") == 1)
                {
                    m_lvlBtns[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = m_star[1];
                }
                if (PlayerPrefs.GetInt($"{i + 1}") == 2)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        m_lvlBtns[i].gameObject.transform.GetChild(j).GetComponent<Image>().sprite = m_star[1];
                    }
                }
                if (PlayerPrefs.GetInt($"{i + 1}") == 3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        m_lvlBtns[i].gameObject.transform.GetChild(j).GetComponent<Image>().sprite = m_star[1];
                    }
                }
            }
        }
    }

    public void LevelInput(int levelNumber)
    {
        if (CountAnlockedLevel >= levelNumber)
        {
            if (SceneManager.sceneCountInBuildSettings > levelNumber)
            {
                SceneManager.LoadSceneAsync(levelNumber);
            }
        }
    }
}
