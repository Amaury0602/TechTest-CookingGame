using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fruit
{
    /// <summary>
    /// Interactable component that allows basic "grab" functionality.
    /// Can attach to a selecting Interactor and follow it around while obeying physics (and inherit velocity when released).
    /// </summary>
    [RequireComponent(typeof(BaseEventListener))]
    public class FruitGenerator : MonoBehaviour
    {
        [Header("Fruits To Spawn")]
        [SerializeField] private GameObject[] fruits;

        [Header("Fruit Generators Locations")]
        [SerializeField] private Transform[] generators;

        [Header("Fruit Speed")]
        [SerializeField] private float easyFruitSpeed = 5f;
        [SerializeField] private float mediumFruitSpeed = 3f;
        [SerializeField] private float hardFruitSpeed = 1f;

        private List<GameObject> spawnedFruits = new List<GameObject>();
        private float selectedFruitSpeed;
        private bool shouldSpawn = false;

        public void StartSpawning()
        {
            if (spawnedFruits.Count > 0)
            {
                foreach (var fruit in spawnedFruits)
                {
                    if (fruit != null) Destroy(fruit);
                }
                spawnedFruits.Clear();
            }
            shouldSpawn = true;
            StartCoroutine(StartSpawnCoroutine());
        }

        private IEnumerator StartSpawnCoroutine()
        {
            while (shouldSpawn)
            {
                yield return new WaitForSeconds(Random.Range(3, 5));
                SpawnFruit();
            }
        }


        private void SpawnFruit()
        {
            if (!shouldSpawn) return;
            int randomNumber = Random.Range(0, fruits.Length);
            FruitMovement newFruitMovement = Instantiate(fruits[randomNumber], generators[randomNumber].position, Quaternion.identity)
                .GetComponent<FruitMovement>();

            newFruitMovement.moveSpeed = selectedFruitSpeed;

            spawnedFruits.Add(newFruitMovement.gameObject);
        }

        public void SetFruitSpeedBasedOnDifficulty(int difficultyIndex)
        {
            switch (difficultyIndex)
            {
                case 0:
                    selectedFruitSpeed = easyFruitSpeed;
                    break;
                case 1:
                    selectedFruitSpeed = mediumFruitSpeed;
                    break;
                case 2:
                    selectedFruitSpeed = hardFruitSpeed;
                    break;
                default:
                    break;
            }
        }

        //This function gets called when the "Timer Ends" Event is triggered
        public void StopSpawning()
        {
            shouldSpawn = false;
            StopCoroutine(StartSpawnCoroutine());
        }
    }
}

