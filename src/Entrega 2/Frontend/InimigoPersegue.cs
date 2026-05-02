using UnityEngine;

public class InimigoPersegue : MonoBehaviour
{
    public Life PlayerLifeScript;
    public Transform player;
    public float velocidade = 3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {

        /*// Esses dois Ifs não são necessários se você for utilizar somente o transform do PlayerRef.
        if (player == null)
            player = PlayerRef.Player;

        if (player == null) return; */

        Vector3 direcao = (PlayerRef.Player.position - transform.position).normalized;
        transform.position += direcao * velocidade * Time.deltaTime;

        transform.LookAt(player);
    }
    private void OnTriggerStay(Collider other) // ao detectar colisao ativa o gatilho
    {
        if (other.CompareTag("Player")) //verifica se o objeto dentro do colisor possui a tag "Player"
        {
            PlayerLifeScript = PlayerRef.PlayerL;
            PlayerLifeScript.TakeDamage();
        }
    }
}
