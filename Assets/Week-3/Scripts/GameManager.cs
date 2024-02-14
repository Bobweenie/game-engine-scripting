using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Battleships
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            //Top left is (0,0)
            { 1,1,0,0,1},
            { 0,0,0,0,0},
            { 0,0,1,0,1},
            { 1,0,1,0,0},
            { 1,0,1,0,1},
        };
        // Represents where the player fired
        private bool[,] hits;

        //Total rows and columns we have
        private int nRows;
        private int nCols;
        //current row/column we are on
        private int row;
        private int cols;
        //correctly hit ships
        private int score;
        //Total time game has been running
        private int time;

        //parent of all cell
        [SerializeField] Transform gridRoot;
        //Templete used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;

        private void Awake()
        {
            //Initalize rows/cols to help us with our operations 
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            //Create identical 2D array to grid that is of the type bool instead of int
            hits = new bool[nRows, nCols];

            //Populate the gid using loop
            //Need to excute as many times to fill up the grid
            //Can  figure that out by calculating rows * cols
            for (int i = 0; i < nRows; i++)
            {
                //Create an instance of the prefab amd child it to the gridRoot
                {
                    Instantiate(cellPrefab, gridRoot);
                }
            }
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}
