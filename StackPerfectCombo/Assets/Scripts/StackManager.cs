using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform lastBlock;
    public float perfectTolerance = 0.15f;

    private bool movingOnX = true;

    public void PlaceBlock(Transform currentBlock)
    {
        float delta;

        if (movingOnX)
        {
            delta = currentBlock.position.x - lastBlock.position.x;
            CutBlock(currentBlock, delta, Vector3.right);
        }
        else
        {
            delta = currentBlock.position.z - lastBlock.position.z;
            CutBlock(currentBlock, delta, Vector3.forward);
        }

        lastBlock = currentBlock;
        currentBlock.GetComponent<MovingPlatform>()?.IncreaseDifficulty();

        movingOnX = !movingOnX;
    }

    void CutBlock(Transform block, float delta, Vector3 dir)
    {
        float size = movingOnX ? block.localScale.x : block.localScale.z;
        float overlap = size - Mathf.Abs(delta);

        if (overlap <= 0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
            return;
        }

       // Perfect combo
if (Mathf.Abs(delta) <= perfectTolerance)
{
    Debug.Log("PERFECT!");

    block.position = new Vector3(
        movingOnX ? lastBlock.position.x : block.position.x,
        block.position.y,
        movingOnX ? block.position.z : lastBlock.position.z
    );
    overlap = size;
}


        // Resize block
        Vector3 scale = block.localScale;
        if (movingOnX) scale.x = overlap;
        else scale.z = overlap;
        block.localScale = scale;

        // Move block to correct position
        block.position -= dir * (delta / 2f);
    }
}
