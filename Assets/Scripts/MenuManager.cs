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

    public Button soundButton;
    public Slider soundSettingSlider;
    AudioSource _gameSong;

    bool timerActive;


    private void Awake()
    {
        //Time.timeScale = 0;
        mainButton.SetActive(true);
    }
    void Start()
    {       
        menuCanvas.SetActive(false);
        bestScore = PlayerPrefs.GetFloat("BestScore", bestScore);
        recordText.text = "Record\n" + bestScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        DeadControl();
        if(timerActive) 
        {
            score += Time.deltaTime*10;
            mainScore.GetComponent<Text>().text = score.ToString("0"); 
        }
        SoundAdjusting();
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
        soundButton.gameObject.SetActive(false);
        soundSettingSlider.gameObject.SetActive(false);
        mainScore.SetActive(true);
        timerActive= true;
        Time.timeScale = 1;
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
        menuCanvas.SetActive(false);
        timerActive = true;
        //score = 0;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SoundButton()
    {
        if(!soundSettingSlider.gameObject.activeSelf) 
        {
            soundSettingSlider.gameObject.SetActive(true);
            _gameSong = FindObjectOfType<DontDestroy>().GetComponent<AudioSource>();
            soundSettingSlider.value = _gameSong.volume;
        }
        else
        {
            soundSettingSlider.gameObject.SetActive(false);
        }
    }

    void SoundAdjusting()
    {
        if (soundSettingSlider.gameObject.activeSelf)
        {
            _gameSong.volume = soundSettingSlider.value;
        }
    }

    public bool TimerActiveCheck()
    {
        return timerActive;
    }
}
