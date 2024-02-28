using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    public float honeyProductionRate = 10f; // Rate of honey production (honey per second)
    public int startingBees = 5; // Starting number of bees
    public GameObject beePrefab; // Reference to the Bee prefab

    private int nectarStored = 0; // Amount of nectar stored
    private int honeyStored = 0; // Amount of honey stored
    private float honeyProductionTimer = 0f; // Timer for honey production

    private void Start()
    {
        // Instantiate starting bees and call their Init function
        for (int i = 0; i < startingBees; i++)
        {
            GameObject beeObj = Instantiate(beePrefab, transform.position, Quaternion.identity);
            Bee bee = beeObj.GetComponent<Bee>();
            if (bee != null)
            {
                bee.Init(this);
            }
        }
    }

    private void Update()
    {
        if (nectarStored > 0)
        {
            // If there is nectar stored, count down to produce honey
            honeyProductionTimer += Time.deltaTime;
            if (honeyProductionTimer >= honeyProductionRate)
            {
                // If the timer reaches the production rate, produce honey
                ProduceHoney();
            }
        }
    }

    private void ProduceHoney()
    {
        // Produce honey and remove nectar accordingly
        honeyStored++;
        nectarStored--;
        honeyProductionTimer = 0f; // Reset the production timer
        Debug.Log("Honey produced!");
    }

    public void GiveNectar()
    {
        // Allow bees to give nectar to the hive
        nectarStored++;
        if (honeyProductionTimer == 0f)
        {
            // Start counting down to produce honey if not already counting down
            honeyProductionTimer = Time.deltaTime;
        }
        Debug.Log("Nectar given to hive!");
    }
}