using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField]
    private Image Player1;

    [SerializeField]
    private Image Player2;

    [SerializeField]
    private Image Player3;

    [SerializeField]
    private Image Player4;

    [SerializeField]
    private TMP_Text timeText;

    [SerializeField]
    private GameObject InGameScreen;

    [SerializeField]
    private GameObject FailScreen;

    [SerializeField]
    private GameObject SuccessScreen;

    public Color AIColor;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AdjustAngryLevel(int AIplayer, float angryLevel)
    {
        if (AIplayer == 1)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player1.GetComponent<Image>().color = AIColor;
        }
        else if (AIplayer == 2)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player2.GetComponent<Image>().color = AIColor;
        }
        else if (AIplayer == 3)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player3.GetComponent<Image>().color = AIColor;
        }
        else if (AIplayer == 4)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player4.GetComponent<Image>().color = AIColor;
        }
        else if (AIplayer == 5)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player3.GetComponent<Image>().color = AIColor;
        }
        else if (AIplayer == 6)
        {
            AIColor = Color.Lerp(Color.green, Color.red, angryLevel);
            Player3.GetComponent<Image>().color = AIColor;
        }
    }

    public void ShowRemainTime(float time)
    {
        timeText.text = time.ToString();
    }

    public void ShowFailScreen()
    {
        InGameScreen.SetActive(false);
        FailScreen.SetActive(true);
    }

    public void ShowSuccessScreen()
    {
        InGameScreen.SetActive(false);
        SuccessScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
