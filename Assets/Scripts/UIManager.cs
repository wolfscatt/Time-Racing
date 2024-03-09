using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void TryAgain()
    {
        GameManager.Instance.StartGame();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }

    public void StartGame(){
        GameManager.Instance.StartGame();
    }
}
