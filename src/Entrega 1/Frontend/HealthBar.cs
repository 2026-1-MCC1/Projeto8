using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageHealthBar;
    private Transform myCamera; // faz referência a câmera


    void Update()
    {
        transform.LookAt(transform.position + myCamera.forward);
    }

    private void Awake()
    {
        myCamera = Camera.main.transform;

    }

    public void alterHealthBar(int currentLife, int maxLife) // declarando vari veis para existirem dentro do contexto (c digo)
    {
        imageHealthBar.fillAmount = (float)currentLife / maxLife; //c lculo para definir o quanto a preencher da barra de vida
    }
}
