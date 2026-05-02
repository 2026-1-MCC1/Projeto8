using UnityEngine;

public class InimigoVS : MonoBehaviour
{
    public Transform player;
    public float velocidade = 3f;

    void Update()
    {
        if (player == null) return;

        // Direção até o player
        Vector3 direcao = (player.position - transform.position).normalized;

        // Move direto até o player
        transform.position += direcao * velocidade * Time.deltaTime;

        // Faz o inimigo olhar pro player (opcional)
        transform.LookAt(player);
    }
}