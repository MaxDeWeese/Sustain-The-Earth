using UnityEngine;
using UnityEngine.SceneManagement;

public class sigma : MonoBehaviour
{
    public void backtomenu()
    {
        SceneManager.LoadScene("start menu");
    }
    public void QuitdaGame()
    {
        Debug.Log("test!!dsgsdgsdsigma sigma");
        Application.Quit();
    }
}
