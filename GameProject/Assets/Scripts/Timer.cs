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

    public Image[] stars; // Attach your star images in the inspector
    public Text lapText;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
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

        
    }

    private void OnTriggerEnter(Collider other)
    {
        lapText.text = "Lap: " + timerText.text;
        timer = 0.0f;
        
        continueButton.SetActive(true);
    }

 
}

