using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    static float timer;
    public GameObject continueButton;

    public Image[] stars;
    public Text lapText;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        ResetTimer(); // Resets timer per level
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        ResetTimer(); // Reset the timer when the game is restarted
    }

    void ResetTimer()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string time = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = time;

        if (Input.GetKeyDown("9"))
        {
            RestartGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        lapText.text = "Lap: " + timerText.text;
        ResetTimer(); 
        continueButton.SetActive(true);
    }
}