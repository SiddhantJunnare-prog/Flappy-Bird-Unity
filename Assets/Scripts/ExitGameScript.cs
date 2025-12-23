using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
    public GameObject ExitGameScreen;
    




    public void QuitGameScreen()
    {
        ExitGameScreen.SetActive(true);
    }

    public void QuitGameYes()
    {
        Application.Quit();
    }

    public void NoQuitGame()
    {
        ExitGameScreen.SetActive(false);
    }


}
