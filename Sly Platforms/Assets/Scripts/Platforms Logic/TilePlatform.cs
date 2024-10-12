using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Implementation of the tile platform trap. Random quarter of the platform falls down when player steps on the one
/// </summary>
public class TilePlatform : MonoBehaviour
{
    [SerializeField] private List<GameObject> tiles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var tileIndex = Random.Range(0, tiles.Count);
            if (tiles.Count > 0)
            {
                StartCoroutine(PerformTileFallingDown(tileIndex));
            }
        }
    }

    private IEnumerator PerformTileFallingDown(int tileIndex)
    {
        GameObject tile = tiles[tileIndex];
        tiles.RemoveAt(tileIndex);
        tile.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(tile);
    }
}
