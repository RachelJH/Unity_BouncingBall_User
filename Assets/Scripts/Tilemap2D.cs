using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap2D : MonoBehaviour
{
    [Header("Tile")]
    [SerializeField]
    private GameObject tilePrefab;

    [Header("Item")]
    [SerializeField]
    private GameObject itemPrefab;

    public void GenerateTileMap(MapData mapData)
    {
        int width = mapData.mapSize.x;
        int height = mapData.mapSize.y;
        
        for(int y = 0; y < height; y++)
        {
            for(int x =0; x< width; x++)
            {
                int index = y * width + x;

                if (mapData.mapData[index] == (int)TileType.Empty)
                {
                    continue;
                }

                Vector3 position = new Vector3(-(width * 0.5f - 0.5f) + x, (height * 0.5f - 0.5f) - y);

                if (mapData.mapData[index] > (int)TileType.Empty && mapData.mapData[index] < (int)TileType.LastIndex)
                {
                    SpawnTile((TileType)mapData.mapData[index], position);
                }
                else if (mapData.mapData[index] == (int)ItemType.Coin)
                {
                    SpawnItem(position);
                }
            }
        }
    }

    private void SpawnTile(TileType tileType, Vector3 position)
    {
        GameObject clone = Instantiate(tilePrefab, position, Quaternion.identity);

        clone.name = "Tile";
        clone.transform.SetParent(transform);

        Tile tile = clone.GetComponent<Tile>();
        tile.Setup(tileType);
    }

    private void SpawnItem(Vector3 position)
    {
        GameObject clone = Instantiate(itemPrefab, position, Quaternion.identity);

        clone.name = "Item";
        clone.transform.SetParent(transform);   
    }
}
