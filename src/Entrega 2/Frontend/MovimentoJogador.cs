using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 5f;
    public Transform cameraTransform;


    void Update()
    {

        // Pega os inputs horizontais e verticais (WASD ou as setas).
        float InputHorizontal = Input.GetAxis("Horizontal");
        float InputVertical = Input.GetAxis("Vertical");

        // Cria dois vetores que pegam a direção da câmera. No caso, cria um vetor com base na câmera para a direita e para trás.

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Zera o eixo Y, impossibilitando do jogador voar ou pular.

        forward.y = 0;
        right.y = 0;

        // Aplica o movimento com base nos vetores baseados na câmera, multiplicados pelos inputs. Faz a normalização desses vetores para determinar uma direção.

        Vector3 movimento = (forward * InputVertical + right * InputHorizontal).normalized;


        // Aplica a atualização de posição no mundo, sendo essa nova posiçao o vetor "movimento" multiplicado pela velocidade e pelo Time.delta.time (esses últimos dois para aplicar uma maior distância de locomoção e deixar o movimento mais fluido).

        transform.position += movimento * velocidade * Time.deltaTime;
    }
}