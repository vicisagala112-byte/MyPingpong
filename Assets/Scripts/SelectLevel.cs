using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField]
    GameObject MultiPlayer;
    [SerializeField]
    GameObject SinglePlayer;


    public void pindahScene(string tujuan)
    {

        SceneManager.LoadScene(tujuan);
    }
}