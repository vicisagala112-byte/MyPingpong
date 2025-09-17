using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mulai;

    public void pindahScene(string tujuan)
    {
        SceneManager.LoadScene(tujuan);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game");
        Application.Quit();
    }
}
