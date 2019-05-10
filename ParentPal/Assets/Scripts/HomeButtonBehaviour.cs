using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void GoToMenu()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(0);
    }
}
