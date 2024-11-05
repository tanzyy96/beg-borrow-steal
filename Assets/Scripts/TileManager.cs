using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableTiles; // Reference to the tilemap game object
    [SerializeField] private Tile hiddenInteractableTile; // Reference to the hidden tile
    [SerializeField] private Tile interactedTile; // Reference to the interacted tile

    // Start is called before the first frame update
    void Start()
    {
        // Seed the hidden tiles in the tilemap
        foreach (var position in interactableTiles.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableTiles.GetTile(position);
            if (tile != null && tile.name == "InteractableVisible")
            {
                interactableTiles.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableTiles.GetTile(position);
        return tile != null && tile.name == "Interactable";
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableTiles.SetTile(position, interactedTile);
    }
}
