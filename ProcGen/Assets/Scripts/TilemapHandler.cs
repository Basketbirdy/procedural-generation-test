using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapHandler : MonoBehaviour
{
    [SerializeField] private KeyCode key = KeyCode.E;
    [Space]
    [Range(0f, 100)]
    [SerializeField] private float density = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            int[,] grid = RandGrid(10, 10);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Debug.Log($"x: {i}; y: {j}; value: {grid[i, j]}");
                }
            }
        }
    }

    int[,] RandGrid(int sizeX, int sizeY)
    {
        int[,] grid = new int[sizeX, sizeY];

        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                float rand = Random.value;
                Debug.Log($"rand: {rand}");
                int value;
                if(rand <= density / 100) { value = 1; }
                else { value = 0; }

                grid[i, j] = value;
            }
        }

        return grid;
    }
}
