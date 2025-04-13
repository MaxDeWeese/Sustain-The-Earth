using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        Debug.Log("test!!dsgsdgsdsigma sigma");
        Application.Quit();
    }
        public void TutorialGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }

}
