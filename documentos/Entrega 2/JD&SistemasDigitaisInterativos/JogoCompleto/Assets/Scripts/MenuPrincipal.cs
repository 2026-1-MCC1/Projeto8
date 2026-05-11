using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject menuPanel;

    public void Play()
    {
        SceneManager.LoadScene("CenaMontada");
        Debug.Log("Funcionando");
    }

    public void Exit()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}
