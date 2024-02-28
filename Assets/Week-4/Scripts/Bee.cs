using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Hive hive; // Reference to the Hive that created the bee

    public void Init(Hive hive)
    {
        this.hive = hive;
    }

    public void SearchForFlowers()
    {
        // Code to search for flowers in the level
    }

    public void FlyToFlower(Vector3 flowerPosition)
    {
        // Use Dotween to move the bee to the flower's position
        transform.DOMove(flowerPosition, 1f).OnComplete(() =>
        {
            // Once arrived at the flower, interact with it
            Flower flower = GetFlowerAtPosition(flowerPosition);
            if (flower != null)
            {
                bool nectarAvailable = flower.TakeNectar();
                // Implement logic based on nectar availability
                if (nectarAvailable)
                {
                    ReturnToHive();
                }
                else
                {
                    SearchForFlowers();
                }
            }
            else
            {
                Debug.LogWarning("No flower found at the destination!");
            }
        }).SetEase(Ease.Linear);
    }



    public void ReturnToHive()
    {
        // Code to return to the hive using Dotween for smooth movement
        transform.DOMove(hive.transform.position, 1f).OnComplete(() =>
        {
            // Once arrived at the hive, give nectar to the hive
            hive.GiveNectar();
            // After giving nectar, search for more flowers
            SearchForFlowers();
        }).SetEase(Ease.Linear);
    }

    private Flower GetFlowerAtPosition(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f); // Adjust the radius as needed
        foreach (Collider2D collider in colliders)
        {
            Flower flower = collider.GetComponent<Flower>();
            if (flower != null)
            {
                return flower;
            }
        }
        return null;
    }
}
