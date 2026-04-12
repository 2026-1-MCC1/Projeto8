using UnityEngine;

public class EquipmentLife : MonoBehaviour
{

    // Variáveis do tipo serializado. Permite visualizar no inspetor mesmo que esteja privado.
    [SerializeField] private int maxLife = 200; // vida maxima do equipamento de 200
  
    [SerializeField] private HealthBar healthBar; // faz referencia a barra de vida

    private int currentLife; // vida atual

    void Start()
    {
        currentLife = maxLife; // vida atual = vida max (200)
        healthBar.alterHealthBar(currentLife, maxLife); // altera a barra de vida com base nas variaveis acima
    }

    private void OnTriggerStay(Collider other) // ao detectar colisao ativa o gatilho
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0)) //verifica se o objeto dentro do colisor possui a tag "Player"
        {
            TakeDamage(15); //toma 15 de dano
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
            Destroy(gameObject);
        }

        Debug.Log("Silencio, pq maquina n fala");
    }
}
