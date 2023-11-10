using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void LoadScene2(int Scene2)
    {
        SceneManager.LoadScene(Scene2); 
    }
}
