using TMPro; // Importante para usar o TextMeshPro
using UnityEngine;

public class EquipmentLife : MonoBehaviour
{
    [SerializeField] private int maxLife = 200;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int pointsValue = 50; // Quanto de pontuação esse objeto vale

    private int currentLife;

    // Variável estática para manter o score entre diferentes instâncias
    public static int totalScore = 0;

    void Start()
    {
        currentLife = maxLife;
        healthBar.alterHealthBar(currentLife, maxLife);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0))
        {
            TakeDamage(15);
        }
    }

    private void TakeDamage(int damage)
    {
        if (currentLife <= 0) return; // Evita processar dano se já estiver morto

        currentLife -= damage;

        if (currentLife < 0) currentLife = 0;

        healthBar.alterHealthBar(currentLife, maxLife);

        if (currentLife <= 0)
        {
            AwardPoints();
            Destroy(gameObject);
        }
    }

    private void AwardPoints()
    {
        totalScore += pointsValue;
        Debug.Log("Pontuação Atual: " + totalScore);

        // Aqui chamaremos a atualização da UI (ver passo abaixo)
        ScoreManager.instance.UpdateScoreUI();
    }
}
