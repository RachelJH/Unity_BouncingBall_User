using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private Tilemap2D tilemap2D;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private CameraController cameraController;

    private void Awake()
    {
        MapDataLoader mapDataLoader = new MapDataLoader();

        MapData mapData = mapDataLoader.Load("Stage01");

        tilemap2D.GenerateTileMap(mapData);
        
        playerController.Setup(mapData.playerPosition);
    
        cameraController.Setup(mapData.mapSize.x, mapData.mapSize.y);
    }
}
