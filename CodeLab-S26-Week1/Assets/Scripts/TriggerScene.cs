using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene : MonoBehaviour
{
    //script for loading a scene changes using collision detector
    //declaring a public string allows me to change the scene in the inspector
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        //checks to see that the game object triggering the collision is the player
        if (other.CompareTag("Player"))
        {
            //loads the scene specified in the inspector
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}