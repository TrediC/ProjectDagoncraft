using UnityEngine;

public class terrainGenerator : MonoBehaviour
{
	public int Width = 256;
	public int Height = 256;
	public int Depth = 20;
	public float Scale = 20f;
	public float OffsetX = 10f;
	public float OffsetY = 10f;

	private Terrain terrain;
	void Start()
	{
		terrain = GetComponent<Terrain>();
		OffsetX = Random.Range(0f, 999f);
		OffsetY = Random.Range(0f, 999f);
	}

	void Update()
	{
		OffsetY += Random.Range(0f, 1f) * Time.deltaTime;
		terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}

	TerrainData GenerateTerrain(TerrainData terrainData)
	{
		terrainData.heightmapResolution = Width + 1;
		terrainData.size = new Vector3(Width, Depth, Height);
		terrainData.SetHeights(0,0, GenerateHeights());


		return terrainData;
	}

	float[,] GenerateHeights()
	{
		float[,] heights = new float[Width, Height];

		for (int x = 0; x < Width; ++x)
		{
			for (int y = 0; y < Height; ++y)
			{
				heights[x, y] = CalculateHeights(x, y);
			}
		}

		return heights;
	}

	float CalculateHeights(int x, int y)
	{
		float xFloat = (float)x / Width * Scale + OffsetX;
		float yFloat = (float)y / Height * Scale + OffsetY;

		return Mathf.PerlinNoise(xFloat, yFloat);
	}
}
