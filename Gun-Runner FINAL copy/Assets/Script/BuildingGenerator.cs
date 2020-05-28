using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public int stories = 5;
    public GameObject[] baseParts;
    public GameObject[] middleParts;
    public GameObject[] topParts;
    public Vector3 normal;

    public void Build()
    {
        float heightOffset = 0;
        heightOffset += SpawnPieceLayer(baseParts, heightOffset);

        for (int i = 2; i < stories; i++)
        {
           heightOffset += SpawnPieceLayer(middleParts, heightOffset);
        }

        SpawnPieceLayer(topParts, heightOffset);
        transform.LookAt(normal, Vector3.down);
    }

        float SpawnPieceLayer(GameObject[] pieceArray, float inputHeight)
        {
            Transform randomTransform = pieceArray[Random.Range(0, pieceArray.Length)].transform;
            GameObject clone = Instantiate(randomTransform.gameObject, this.transform.position
                + new Vector3(0, inputHeight, 0), Quaternion.identity) as GameObject;
        //clone.transform.LookAt(normal);
            Mesh cloneMesh = clone.GetComponentInChildren<MeshFilter>().mesh;
            Bounds bounds = cloneMesh.bounds;
            float heightOffset = bounds.size.y;

            clone.transform.SetParent(this.transform);

            return heightOffset;
        
    }
}
