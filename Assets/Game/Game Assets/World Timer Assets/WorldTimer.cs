using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class WorldTimer : MonoBehaviour
{
    float totalTime = 120f; // 2 minutes
    public TextMeshProUGUI timerText;
    public PostProcessVolume pp;
    private Bloom bloom;
    private ColorGrading colorGrading;
    bool bYouWin = false;
    Color targetColor = Color.black;
    public Canvas canvas;
    void Update()
    {
        if (Time.timeScale > 0)
        {
            totalTime -= Time.deltaTime; // Use Time.deltaTime when the game is running
        }
        else
        {
            totalTime -= Time.unscaledDeltaTime; // Use Time.unscaledDeltaTime when the game is paused
        }

        if (totalTime > 0)
        {
            UpdateLevelTimer(totalTime);
        }
        else if (totalTime <= 0 && !bYouWin)
        {
            YouWin();
        }

        if (bYouWin)
        {
            IncreaseBloom();
        }
    }

    private void Start()
    {
        pp.profile.TryGetSettings(out bloom);
        pp.profile.TryGetSettings(out colorGrading);
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formattedSeconds = seconds.ToString("00");
        string formattedMinutes = minutes.ToString("00");

        timerText.text = $"{formattedMinutes}:{formattedSeconds}";
    }

    void IncreaseBloom()
    {
        if (bloom.intensity.value < 50F)
        {
            bloom.intensity.value += Time.unscaledDeltaTime * (50F / 15F);
        }

        if (colorGrading.colorFilter.value != targetColor && bloom.intensity.value > 10F)
        {
            colorGrading.colorFilter.value = Color.Lerp(colorGrading.colorFilter.value, targetColor, Time.unscaledDeltaTime / 1F);
        }

        if (colorGrading.colorFilter.value == targetColor)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        // Implement game finish logic here

        SceneManager.LoadScene(3);
        bYouWin = false;
        Time.timeScale = 1F;
    }

    public void YouWin()
    {
        canvas.gameObject.SetActive(false);
        
        bYouWin = true;
        Time.timeScale = 0F;
    }
}
