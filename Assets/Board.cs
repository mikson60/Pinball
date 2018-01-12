using UnityEngine;

public class Board : MonoBehaviour {

    [SerializeField] Transform middleAnchor;

    public Vector3 GetMiddleAnchorPosition(bool useWorldCoords = true)
    {
        if (middleAnchor == null) { Debug.LogWarning("Board.GetMiddleAnchorPosition(): MiddleAnchor not set!"); return Vector3.zero; }
        return (useWorldCoords ? middleAnchor.position : middleAnchor.localPosition );
    }
}
