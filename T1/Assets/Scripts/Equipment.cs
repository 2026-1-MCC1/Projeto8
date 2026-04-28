using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject equipmentPrefab;

    private List<GameObject> equipmentList = new List<GameObject>();
    //uma lista para armazenar os equipamentos que irao spawnar

    private List<Vector3> equipmentPositions = new List<Vector3>();
    //uma lista para armazenar a posição dos equipamentos ja spawnados

    void Start()
    {
        SpawnEquipment();
    }

    private void SpawnEquipment()
    {
        float minDistance = 20f;

        int equipmentQuantidity = Random.Range(2, 5); // gera um num aleatorio que sera a quantidade de equipamentos

        for (int i = 0; i < equipmentQuantidity; i++) // looping que controla quantos equipamentos serao criados
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-45, 45), 2, Random.Range(-45, 45));
            // gera posicoes aleatorias, X; Y; Z, usando Random.Range (inclusivo, exclusivo)

            int attempt = 0;
            bool validPosition = false;

            // enquanto a posicao ja estiver ocupada (tiver a posicao aleatoria armazenada) E ainda houver tentativas disponíveis (menor que 10)
            while (!validPosition && attempt < 10)
            {
                randomSpawnPosition = new Vector3(Random.Range(-55, 55), 2, Random.Range(-55, 55));
                // gera uma nova posicao

                validPosition = true;
                //posicao valida

                //para cada pos na lista de posicoes de equipamento
                foreach (Vector3 pos in equipmentPositions)
                {
                    //se a pos (gerada por posicao aleatoria) for menor que a distancia minima
                    if (Vector3.Distance(pos, randomSpawnPosition) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
                }

                attempt++;
                //soma as tentativas
            }

            //se cada tentativa de um novo equipamento a posicao estiver ocupada (dentro da lista de posicoes aleatorias)
            if (equipmentPositions.Contains(randomSpawnPosition))
            {
                Debug.Log("Sem posição livre"); // acabou as posicoes
                return; // termina tudo (SpawnEquipment)
            }

            //entao se o if nao for atendido ele ira:

            equipmentPositions.Add(randomSpawnPosition); // adiciona a posicao aleatoria na lista de posicoes dos equipamentos

            GameObject newEquipment = Instantiate(equipmentPrefab, randomSpawnPosition, Quaternion.identity);
            // criar um novo equipamento

            equipmentList.Add(newEquipment);
            // adiciona o equipamento a lista
        }
    }
}