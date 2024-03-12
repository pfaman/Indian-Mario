
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static Vector2 lastCheckPointPos =new Vector2(-6,1);
    public TextMeshProUGUI coinText;

    public static int numberOfCoins;

    public GameObject[] playerPrefabs;
    public CinemachineVirtualCamera vCam;


    int characterIndex;
    private void Awake()
    {
       
        characterIndex=PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player= Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);
        vCam.m_Follow = player.transform;
        isGameOver = false;
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    private void Update()
    {
        coinText.text = " " + numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {

        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
