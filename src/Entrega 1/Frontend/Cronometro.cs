using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    [Header("Configuracoes de Tempo")]
    // O tempo total que o jogo terá (150 segundos = 2m 30s)
    public float tempoInicial = 150f;

    [Header("Componentes de UI")]
    public TextMeshProUGUI textoTempo;

    private float tempoAtual;       // Armazena quanto tempo resta no momento
    private bool cronometroRodando; // Controla se o tempo deve diminuir ou ficar parado

    void Start()
    {
        tempoAtual = tempoInicial;  // Começa o cronômetro com o valor total (150)
        cronometroRodando = true;   // Ativa o cronômetro para começar a contar
        AtualizarTexto();           // Chama a função para mostrar o tempo inicial na tela
    }

    void Update()
    {
        // Se o cronômetro estiver pausado, ele "sai" do Update aqui e não faz nada
        if (!cronometroRodando) return;

        // Time.deltaTime é o tempo exato que passou entre um frame e outro.
        // Subtrai esse valor do nosso tempo atual.
        tempoAtual -= Time.deltaTime;

        // Verifica se o tempo chegou ou passou de zero
        if (tempoAtual <= 0f)
        {
            tempoAtual = 0f;           // Garante que não apareçam números negativos
            cronometroRodando = false; // Para a contagem
            TempoEsgotado();           // Avisa que o tempo acabou
        }

        // Atualiza o que aparece escrito na tela a cada segundo que passa
        AtualizarTexto();
    }

    // Função responsável por transformar segundos 
    void AtualizarTexto()
    {
        // Divide o tempo por 60 para achar os minutos (pega só a parte inteira)
        int minutos = Mathf.FloorToInt(tempoAtual / 60f);

        // O resto da divisão por 60 são os segundos
        int segundos = Mathf.FloorToInt(tempoAtual % 60f);

        // Atualiza o componente de texto. 
        textoTempo.text = string.Format("{0}:{1:00}", minutos, segundos);
    }

    // O que acontece quando o tempo chega em 0:00
    void TempoEsgotado()
    {
        Debug.Log("O tempo acabou!"); // Escreve uma mensagem no Console da Unity
        textoTempo.text = "0:00";     // Garante que o texto mostre zero

        // Colocar a tela de Game Over
    }
}