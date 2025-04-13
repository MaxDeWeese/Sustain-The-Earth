using UnityEngine;
using UnityEngine.SceneManagement;

public class yes : MonoBehaviour
{
        public void ContinueGame()
    {
        Debug.Log("test!!dsgsdgsdsigma sigma");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }
}
