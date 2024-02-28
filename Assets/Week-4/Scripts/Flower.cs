using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float nectarProductionRate = 5f; // Rate of nectar production (nectar per second)
    public Color nectarReadyColor; // Color of the flower when nectar is ready
    public Color nectarNotReadyColor; // Color of the flower when nectar is not ready

    private bool hasNectar = false; // Whether the flower has nectar
    private float nectarProductionTimer = 0f; // Timer for nectar production

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        UpdateFlowerColor(); // Update flower color based on nectar availability
    }

    private void Update()
    {
        if (!hasNectar)
        {
            // If the flower doesn't have nectar, start the nectar production timer
            nectarProductionTimer += Time.deltaTime;
            if (nectarProductionTimer >= nectarProductionRate)
            {
                // If the timer reaches the production rate, produce nectar
                ProduceNectar();
            }
        }
    }

    private void ProduceNectar()
    {
        hasNectar = true; // Set the flower to have nectar
        nectarProductionTimer = 0f; // Reset the production timer
        UpdateFlowerColor(); // Update flower color based on nectar availability
        Debug.Log("Nectar produced!");
    }

    private void UpdateFlowerColor()
    {
        // Change the color of the flower based on nectar availability
        spriteRenderer.color = hasNectar ? nectarReadyColor : nectarNotReadyColor;
    }

    public bool IsNectarAvailable()
    {
        // Returns true if the flower has nectar available
        return hasNectar;
    }

    public bool TakeNectar()
    {
        // Allows a Bee to "take" nectar from the flower
        if (hasNectar)
        {
            hasNectar = false; // Flower loses nectar
            UpdateFlowerColor(); // Update flower color based on nectar availability
            Debug.Log("Nectar taken!");
            return true; // Return true if nectar was taken
        }
        else
        {
            return false; // Return false if no nectar available
        }
    }
}
