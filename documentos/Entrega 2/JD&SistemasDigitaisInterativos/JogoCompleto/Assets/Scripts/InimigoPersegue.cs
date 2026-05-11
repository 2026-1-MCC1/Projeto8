using System.Collections;
using UnityEngine;

public class InimigoPersegue : MonoBehaviour
{
    public Life PlayerLifeScript;
    public Transform player;
    public GameObject EnemyRef;

    public float velocidade = 8f;
    public float distanciaPerseguicao = 30f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerLifeScript = player.GetComponent<Life>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        // Só persegue se estiver perto
        if (distancia <= distanciaPerseguicao)
        {
            Vector3 direcao = (player.position - transform.position).normalized;

            transform.position += direcao * velocidade * Time.deltaTime;

            Vector3 RotationRef = player.transform.position;
            RotationRef.y = transform.position.y;

            transform.LookAt(RotationRef);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Coroutine(15f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    private IEnumerator Coroutine(float DelayTime)
    {
        PlayerLifeScript.TakeDamage();
        yield return new WaitForSeconds(DelayTime);
    }
}