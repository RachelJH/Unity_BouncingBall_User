using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBroke : Tile
{
    [SerializeField]
    private GameObject tileBorkeEffect;

    public override void Collision(CollisionDirection direction)
    {
        Instantiate(tileBorkeEffect, transform.position, Quaternion.identity);

        if(direction == CollisionDirection.Down)
        {
            movement2D.JumpTo();
        }

        Destroy(gameObject);
    }
}
