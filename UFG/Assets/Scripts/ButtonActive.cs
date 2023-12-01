using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonActive : MonoBehaviour
{
    public GameObject nextScreen;
    /*Tiny function to workaround Unity button Animation Limitations*/
    public void Next()
    {
        nextScreen.SetActive(true);
        this.transform.gameObject.SetActive(false);
    }
    /*Allows for animations to change the scene*/
    public void MultiplayerScene()
    {
        SceneManager.LoadScene(1);
    }
    /*Allows for animations to change the scene*/
    public void SinglePlayerScene()
    {
        SceneManager.LoadScene(2);
    }
}
