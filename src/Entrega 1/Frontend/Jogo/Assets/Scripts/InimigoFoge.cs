using UnityEngine;
using UnityEngine.AI; // IMPORTANTE!

// Coloca esse script no GameObject do inimigo
public class InimigoFoge : MonoBehaviour
{
    // ===== VARIÁVEIS PÚBLICAS =====

    public float raioFuga = 5f;
    public float velocidadeFuga = 4f;
    public float raioSeguranca = 10f;

    public Transform jogador;

    // ===== VARIÁVEIS PRIVADAS =====

    private NavMeshAgent agente;
    private bool estahFugindo = false;

    void Start()
    {
        if (jogador == null)
        {
            Debug.LogError("Jogador NÃO encontrado!");
        }
        // Pega o NavMeshAgent corretamente
        agente = GetComponent<NavMeshAgent>();

        // Segurança: verifica se existe
        if (agente == null)
        {
            Debug.LogError("NavMeshAgent não encontrado no inimigo!");
            return;
        }

        agente.speed = velocidadeFuga;

        // Tenta encontrar o jogador automaticamente
        if (jogador == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
                jogador = obj.transform;
            else
                Debug.LogWarning("Jogador não encontrado! Verifique a tag 'Player'.");
        }
    }

    void Update()
    {
        Vector3 teste = new Vector3(14, 0, -29);
        agente.SetDestination(teste);

        if (jogador == null || agente == null) return;

        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia < raioFuga)
        {
            estahFugindo = true;
            Fugir();
        }
        else if (estahFugindo && distancia > raioSeguranca)
        {
            estahFugindo = false;
            agente.ResetPath();
        }
    }

    void Fugir()
    {
        // Direção oposta ao jogador
        Vector3 direcaoFuga = (transform.position - jogador.position).normalized;

        // Calcula destino
        Vector3 destinoFuga = transform.position + direcaoFuga * raioSeguranca;

        // Garante que o ponto está no NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destinoFuga, out hit, 2f, NavMesh.AllAreas))
        {
            agente.SetDestination(hit.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioFuga);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioSeguranca);
    }
}
