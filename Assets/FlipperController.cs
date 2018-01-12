using UnityEngine;

public class FlipperController : MonoBehaviour {

    [SerializeField] Flipper m_flipper;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hit))
                {
                    if (hit.collider != null)
                    {
                        FlipperController flipperController = hit.collider.GetComponent<FlipperController>();
                        if (flipperController != null && flipperController == this)
                        {
                            m_flipper.isTouched = true;
                        }
                    }
                }
            }
        }
    }
}
