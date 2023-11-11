using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceLink : MonoBehaviour
{
  public void Link() 
    {
        Application.OpenURL("https://github.com/B00150644/GameProject");
    }
    public void OpenURL(string link) 
    {
        Application.OpenURL(link);
    }
}
