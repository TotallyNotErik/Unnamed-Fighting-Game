using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonActive : MonoBehaviour
{
    public GameObject nextScreen;

    public void Next()
    {
        nextScreen.SetActive(true);
        this.transform.gameObject.SetActive(false);
    }
    public void MultiplayerScene()
    {
        SceneManager.LoadScene(1);
    }
}
