using UnityEngine;

public enum FlapperType { P1_Left, P1_Right, P2_Left, P2_Right }

[RequireComponent(typeof(HingeJoint))]
public class Flipper : MonoBehaviour {

    public FlapperType type;

    [SerializeField] float restPosition = 0f;
    [SerializeField] float pressedPosition = 45f;
    [SerializeField] float hitStrength = 10000f;
    [SerializeField] float flipperDamper = 150f;

    HingeJoint m_hinge;
    Quaternion startingRot;
    Rigidbody m_rigidbody;

    float swingDuration = 0.1f;
    bool isSwinging = false;

    public bool isTouched = false;

	void Awake () {
        m_hinge = GetComponent<HingeJoint>();
        m_hinge.useSpring = true;

        m_rigidbody = GetComponent<Rigidbody>();
        startingRot = m_rigidbody.rotation;
    }

    void Update()
    {
        JointSpring spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };

        if (isTouched)
        {
            spring.targetPosition = pressedPosition;
        } else
        {
            spring.targetPosition = restPosition;
        }

        m_hinge.spring = spring;

        isTouched = false;
        /*
        
        
        if (Input.GetKey(KeyCode.LeftArrow) && type == FlapperType.P1_Left)
        {
            spring.targetPosition = pressedPosition;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && type == FlapperType.P1_Right)
        {
            spring.targetPosition = pressedPosition;
        }
        else if (Input.GetKey(KeyCode.A) && type == FlapperType.P2_Left)
        {
            spring.targetPosition = pressedPosition;
        }
        else if (Input.GetKey(KeyCode.D) && type == FlapperType.P2_Right)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }


        
        // m_hinge.useLimits = true;
        */
    }

    public void Swing()
    {
        JointSpring spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };

        spring.targetPosition = pressedPosition;
        m_hinge.spring = spring;
    }

    public void Rest()
    {
        JointSpring spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };

        spring.targetPosition = restPosition;
        m_hinge.spring = spring;
    }

    /*
    IEnumerator SwingRoutine()
    {
        if (!isSwinging) {
            yield return StartCoroutine(SwingRoutineConcrete(endRotY, swingDuration));
            yield return StartCoroutine(SwingRoutineConcrete(startingRot.eulerAngles.y, swingDuration));
        }

    }

    IEnumerator SwingRoutineConcrete(float endRot, float timeToRotate) {

        isSwinging = true;
        
        Quaternion startRotation = m_rigidbody.rotation;
        float elapsedTime = 0f;
        float t = 0;

        while (t < 1)
        {
            elapsedTime += Time.fixedDeltaTime;
            t = Mathf.Clamp01(elapsedTime / timeToRotate);

            m_rigidbody.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, endRot, 0), t);
            m_rigidbody.velocity = new Vector3(0, 100 / t, 0);

            yield return new WaitForFixedUpdate();
        }
        isSwinging = false;
        m_rigidbody.angularVelocity = Vector3.zero;
    }
    */
}
