using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region ==Start&Update==
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region ==MainMenu==
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    #endregion

    #region ==MainScene==

    #endregion

}
