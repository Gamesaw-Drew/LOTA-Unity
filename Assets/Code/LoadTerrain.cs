using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTerrain : MonoBehaviour {
	public Texture2D heightMap;
	private float[,] heightValues;

	// Use this for initialization
	void Start () {
	heightValues = new float[ 513, 513 ];
	LoadHeightmap( heightMap );
	}

	private void LoadHeightmap( Texture2D heightmap )
	{
		// Acquire an array of colour values.
		Color[] values = heightmap.GetPixels();

		// Run through array and read height values.
		int index = 0;
		for ( int z = 0; z < heightmap.height; z++ )
		{
			for ( int x = 0; x < heightmap.width; x++ )
			{
				heightValues[ z, x ] = values[ index ].r;
				index++;
			}
		}
		GetComponent<TerrainData> ().SetHeights (0, 0, heightValues);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
