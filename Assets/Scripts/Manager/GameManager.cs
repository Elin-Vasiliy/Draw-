using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;

    public Image meter;
    public float Star_3;
    public float Star_2;
    public float Star_1;

    public void GameWin()
    {
        if (meter.fillAmount > Star_3)
        {
            if (PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().buildIndex}") != 3)
            {
                PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().buildIndex}", 3);
                PlayerPrefs.Save();
            }
        }
        else if (meter.fillAmount < Star_3 && meter.fillAmount > Star_2)
        {
            if (PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().buildIndex}") != 2 && PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().buildIndex}") != 3)
            {
                PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().buildIndex}", 2);
                PlayerPrefs.Save();
            }
        }
        else if (meter.fillAmount < Star_2)
        {
            if (PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().buildIndex}") != 1 && PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().buildIndex}") < 2)
            {
                PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().buildIndex}", 1);
                PlayerPrefs.Save();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == LvlManager.CountAnlockedLevel)
        {
            LvlManager.CountAnlockedLevel++;
            PlayerPrefs.SetInt("CountAnlockedLevel", LvlManager.CountAnlockedLevel);
            PlayerPrefs.Save();
        }

        GameWinPanel.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        GameOverPanel.SetActive(true);
    }

    private void SaveData(string nameKey, int numberKey)
    {
        PlayerPrefs.SetInt($"{nameKey}", numberKey);
        PlayerPrefs.Save();
    }
}
