using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageHealthBar;

    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public void alterHealthBar(int currentLife, int maxLife) // declarando variáveis para existirem dentro do contexto (código)
    {
        imageHealthBar.fillAmount = (float) currentLife / maxLife; //cálculo para definir o quanto a preencher da barra de vida
    }
}
