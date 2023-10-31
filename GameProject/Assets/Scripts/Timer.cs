using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    static float timer;

    public Image[] stars; // Attach your star images in the inspector
    public Text lapText;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
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

        UpdateStars(); // Call the function to update stars
    }

    private void OnTriggerEnter(Collider other)
    {
        lapText.text = "Lap: " + timerText.text;
        timer = 0.0f;
    }

    private void UpdateStars()
    {
        if (timer < 180) // Less than 3 minutes
        {
            SetStars(3); // Show 3 stars
        }
        else if (timer < 240) // Less than 4 minutes
        {
            SetStars(2); // Show 2 stars
        }
        else
        {
            SetStars(1); // Show 1 star
        }
    }

    private void SetStars(int numStars)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < numStars;
        }
    }
}

