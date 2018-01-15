using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

    Rigidbody m_rb;
    Board m_board;

	void Awake () {
        m_rb = GetComponent<Rigidbody>();
        Init();
	}

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        CheckBounds();
    }

    void FixedUpdate()
    {
        ApplyBoardGravity();
    }

    void Init()
    {
        m_board = FindObjectOfType<Board>();
    }

    void ApplyBoardGravity()
    {
        if (m_board == null) { Debug.LogWarning("Ball.ApplyBoardGravity(): Board not set!"); return; }
        if (m_board.GetMiddleAnchorPosition().z >= transform.position.z)
        {
            m_rb.AddForce(-Vector3.forward * 9.8f * 50 * Time.deltaTime);
        }
        else
        {
            m_rb.AddForce(Vector3.forward * 9.8f * 50 * Time.deltaTime);
        }
    }

    void CheckBounds()
    {
        if (transform.position.z < -3.5f)
        {
            ScoreManager.Instance.AddScoreP2();
            ResetBall();
        }
        else if (transform.position.z > 23f)
        {
            ScoreManager.Instance.AddScoreP1();
            ResetBall();
        }
    }

    public void ResetBall()
    {
        m_rb.velocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(5.75f, 9f), 1.25f, Random.Range(6.5f, 13f));
    }
}
