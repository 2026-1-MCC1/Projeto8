using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        // WASD ou setas movem o jogador
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(x, 0, z);
        transform.position += movimento * velocidade * Time.deltaTime;
    }
}
