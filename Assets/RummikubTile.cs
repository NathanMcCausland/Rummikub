using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Rummikub;

public class RummikubTile : MonoBehaviour
{
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    RummikubTileData tile_data;

    public void SetMesh(Mesh mesh)
    {
        meshFilter.mesh = mesh;
    }

    public void SetMaterial(Material material)
    {
        meshRenderer.material = material;
    }

    public void SetData(RummikubTileData data)
    {
        tile_data = data;
    }
}
