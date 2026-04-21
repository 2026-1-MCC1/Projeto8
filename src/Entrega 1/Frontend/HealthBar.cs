using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageHealthBar; // imagem da barra
    private Transform myCamera; // faz refer�ncia a c�mera
    
    private void Awake()
    {
        myCamera = Camera.main.transform; //camera ne

    }

    void Update()
    {
        transform.LookAt(transform.position + myCamera.forward); // faz com a barra fique "de frente" para a camera, evitando que ela suma do nada
    }


    public void alterHealthBar(int currentLife, int maxLife) // declarando vari veis para existirem dentro do contexto (c digo)
    {
        imageHealthBar.fillAmount = (float)currentLife / maxLife; //calculo para definir o quanto a preencher da barra de vida
        //ou seja ao realizar a divisao, a barra vai diminuir
    }
}