using UnityEngine;

public class ForLoop : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject cube1;
    public GameObject cube2;
    public float spacing;
    public float width = 5;
    public float height = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width ; x++)
            {
                Vector3 offset = Vector3.right * (1 + spacing) / 2 * y;
                offset = Vector3.zero;
                bool isOnEdge = x ==0 || x == width - 1 || y == 0 || y == height - 1;

                GameObject toSpawn = isOnEdge? cube1 : cube2;
                Instantiate(toSpawn, new Vector3(x + spacing + spacing * x, y + spacing + spacing * y, 0) + offset, Quaternion.identity);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
