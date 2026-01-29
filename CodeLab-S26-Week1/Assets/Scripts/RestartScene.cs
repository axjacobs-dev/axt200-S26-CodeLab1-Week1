using UnityEngine;
using UnityEngine.SceneManagement;
//basic script for restarting a scene
public class RestartScene : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
