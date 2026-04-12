using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject equipmentPrefab;

    private List<GameObject> equipmentList = new List<GameObject>();
    //uma lista para armazenar os equipamentos que irão spawnar
    private List<Vector3> equipmentPositions = new List<Vector3>();
    //uma lista para armazenar a posição dos equipamentos já spawnados
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnEquipment();
        }
        //SpawnEquipment();
    }

    private void SpawnEquipment()
    {
        int equipmentQuantidity = Random.Range(2, 5);

        for (int i = 0; i < equipmentQuantidity; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(1, 3), 2, Random.Range(0, 2));

            /* vai spawnar aleatoriamente com base nos valores x,y e z (Vector3): sendo x incluindo 1 e
            excluindo o 3 (ou seja, vai spawnar entre 1 e 2), y sendo 2 e z sendo entre 0 e 1. */

            while (equipmentPositions.Contains(randomSpawnPosition)) ; // enquanto a lista de posições de equipamentos conter a posição aleatória

            equipmentPositions.Add(randomSpawnPosition); // adiciona a posição aleatória na lista de posições dos equipamentos

            GameObject newEquipment = Instantiate(equipmentPrefab, randomSpawnPosition, Quaternion.identity); // após a 

            equipmentList.Add(newEquipment);
        }
    }
}
