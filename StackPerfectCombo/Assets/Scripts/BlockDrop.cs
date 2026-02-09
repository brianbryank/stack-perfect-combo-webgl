using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    private bool dropped = false;

    void Update()
    {
        if (!dropped && Input.GetMouseButtonDown(0))
        {
            dropped = true;
            FindObjectOfType<StackManager>().PlaceBlock(transform);
        }
    }
}
