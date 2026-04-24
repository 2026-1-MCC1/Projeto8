using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instância estática para que outros scripts acessem via GameManager.instance
    public static GameManager instance;

    [SerializeField] private int totalHouses; // Quantidade de equipamentos/casas na cena
    [SerializeField] private TextMeshProUGUI houseText;

    void Awake()
    {
        // Configuração do Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Chamado pelo script 'Equipment' logo após o Spawn
    public void SetTotalHouses(int amount)
    {
        totalHouses = amount;
        UpdateUI();
    }

    // Chamado pelo script 'EquipmentLife' quando a vida chega a 0
    public void HouseDestroyed()
    {
        totalHouses--;
        UpdateUI();

        Debug.Log("Equipamento destruído! Restam: " + totalHouses);

        if (totalHouses <= 0)
        {
            Debug.Log("Missão cumprida: Todos os equipamentos foram destruídos!");
        }
    }

    // Atualiza o texto na interface (UI)
    private void UpdateUI()
    {
        if (houseText != null)
        {
            houseText.text = "Casas Restantes: " + totalHouses;
        }
    }
}