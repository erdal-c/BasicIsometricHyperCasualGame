using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    float score;
    float bestScore;
    public GameObject menuCanvas;
    public GameObject mainScore;
    public GameObject mainButton;
    public Text panelScoreText;
    public Text mainBoardText;
    public Text recordText;
    public Text loseMenuNewRecordText;

    bool timerActive;


    private void Awake()
    {
        mainButton.SetActive(true);
    }
    void Start()
    {       
        menuCanvas.SetActive(false);
        bestScore = PlayerPrefs.GetFloat("BestScore", bestScore);
        recordText.text = "Record\n" + bestScore.ToString("0");
    }

    void Update()
    {
        DeadControl();
        if(timerActive) 
        {
            score += Time.deltaTime*10;
            mainScore.GetComponent<Text>().text = score.ToString("0");
        }
    }

    void DeadControl()
    {
        if (PlayerControler.GetInstance().DeadCheck())
        {
            menuCanvas.SetActive(true);
            timerActive= false;
            panelScoreText.text = "Score : " + score.ToString("0");
            mainScore.SetActive(false);
            if(score> bestScore)
            {
                bestScore = score;
                loseMenuNewRecordText.gameObject.SetActive(true);
                PlayerPrefs.SetFloat("BestScore", bestScore);
            }
        }
    }
        

    public void MainPlayButton()
    {
        mainButton.SetActive(false);
        mainBoardText.gameObject.SetActive(false);
        recordText.gameObject.SetActive(false);
        mainScore.SetActive(true);
        timerActive= true;
        Time.timeScale = 1;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
        menuCanvas.SetActive(false);
        timerActive = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public bool TimerActiveCheck()
    {
        return timerActive;
    }
}
