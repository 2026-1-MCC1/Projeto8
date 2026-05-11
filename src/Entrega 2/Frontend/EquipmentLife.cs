using TMPro; // Importante para usar o TextMeshPro
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipmentLife : MonoBehaviour
{

    // Variáveis do tipo serializado. Permite visualizar no inspetor mesmo que esteja privado.
    [SerializeField] private int maxLife = 200; // vida maxima do equipamento de 200

    [SerializeField] private HealthBar healthBar; // faz referencia a barra de vida

    [SerializeField] private int pointsValue = 50; // Quanto de pontuação esse objeto vale

    [SerializeField] private int currentLife; // vida atual

    public static int totalScore = 0;

    public static int totalEquipments;

    void Start()
    {
        totalEquipments++;

        currentLife = maxLife; // vida atual = vida max (200)
        healthBar.alterHealthBar(currentLife, maxLife); // altera a barra de vida com base nas variaveis acima
    }

    private void OnTriggerStay(Collider other) // ao detectar colisao ativa o gatilho
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0)) //verifica se o objeto dentro do colisor possui a tag "Player"
        {
            TakeDamage(5); //toma 15 de dano
        }
    }

    private void TakeDamage(int damage) //metodo de tomar dano, o dano é no tipo inteiro
    {
        currentLife -= damage; // o dano desconta da vida atual

        if (currentLife < 0) // se a vida atual e menor que 0
            currentLife = 0; // vida atual = 0

        healthBar.alterHealthBar(currentLife, maxLife); // altera a barra de vida

        if (currentLife <= 0) // se a vida for igual ou menor que 0, destroi o obj
        {
            AwardPoints();

            totalEquipments--;

            if (totalEquipments <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            Destroy(gameObject);

        }

        // Debug.Log("Silencio, pq maquina n fala");
    }
    private void AwardPoints()
    {
        totalScore += pointsValue;
        Debug.Log("Pontuação Atual: " + totalScore);

        // Aqui chamaremos a atualização da UI (ver passo abaixo)
        ScoreManager.instance.UpdateScoreUI();
    }
}
