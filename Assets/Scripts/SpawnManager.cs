using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawningObjects; //Es un arreglo

    [SerializeField]
    Transform[] spawningPoints; //Es un arreglo

    [SerializeField]
    float timeBetweenSpawn = 3.0F; //Tiempo entre cada spawn

    float _currentTime;
    float _speedMultipler;

    void Start()
    {
        _currentTime = timeBetweenSpawn;
    }

    void Update()
    {
        //Incrementa el tiempo por cada frame
        _currentTime += Time.deltaTime;

        _speedMultipler += Time.deltaTime * 0.1F;

        //Si el tiempo es igual o mayor al tiempo entre objetos
        if (_currentTime >= timeBetweenSpawn)
        {
            //Resetea el tiempo
            _currentTime = 0.0F;

            //Asigna aleatoreamente un nuevo objeto para hacerlo aparecer
            int spawningIndex = Random.Range(0, spawningObjects.Length);
            Transform prefab = spawningObjects[spawningIndex];

            //Asigna la posicion en la que puede aparecer
            SpawningObjectController controller = prefab.GetComponent<SpawningObjectController>();
            int[] spawningPoints = controller.GetSpawningPoints();
            spawningIndex = spawningPoints[Random.Range(0, spawningPoints.Length)];

            //Crea la instancia del prefab
            foreach (Transform point in this.spawningPoints)
            {
                if (point.gameObject.name.Equals("Point" + spawningIndex.ToString()))
                {
                    Instantiate(prefab, point.position, Quaternion.identity);
                    break;
                }
            }
        }
    }

    public float GetSpeedMultiplier()
    {
        return _speedMultipler;
    }
}
