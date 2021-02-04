using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize = new Vector3(1, 1, 1);
    [SerializeField] private Vector3 size = new Vector3(1, 1, 1);

    private void Start()
    {
        NewScale();
    }

    private void OnDrawGizmos()
    {
        SnapToGrid();
    }

    protected void SnapToGrid()
    {
        Vector3 position = new Vector3(
            Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
            Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
            Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.z
        );

        this.transform.position = position;
    }

    public void NewScale()
    {
        Vector3 actualSize = this.GetComponent<Renderer>().bounds.size;

        Vector3 rescale = this.transform.localScale;

        rescale = new Vector3(size.x * rescale.x / actualSize.x, size.y * rescale.y / actualSize.y, 1);

        this.transform.localScale = rescale;
    }
}
