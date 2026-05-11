using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Pontuação: " + EquipmentLife.totalScore;
    }
}