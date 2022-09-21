using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    Transform body;

    float m_vertical;
    float m_horizontal;
    float m_v = 0f;
    float vx;
    float vy;
    float m_a = 2.5f;

    bool m_accelerationMove = true;

    bool negativeY = false;
    bool negativeX = false;

    void Start()
    {
        body = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        m_horizontal = Input.GetAxisRaw("Horizontal");
        m_vertical = Input.GetAxisRaw("Vertical");
        Vector2 m_input = new Vector2(m_horizontal,m_vertical);
        m_input.Normalize();

        if(m_input.magnitude > 0)
        {
            m_v += m_a * Time.deltaTime;
            m_v = Mathf.Clamp(m_v, 0, 1.5f);
        }
        else
        {
            m_v -= m_a * Time.deltaTime;
            m_v = Mathf.Clamp(m_v, 0, 1.5f);
        }

        DeaccelerationFixer();
        body.transform.position = body.transform.position + 
            new Vector3(m_input.x/3 + vx * Time.deltaTime, m_input.y/3 + vy * Time.deltaTime);


        /*if(m_accelerationMove)
            body.transform.position = body.transform.position + new Vector3(m_input.x * m_v * Time.deltaTime, m_input.y * m_v * Time.deltaTime);
        else
            body.transform.position += new Vector3(m_input.x * m_v * Time.deltaTime, m_input.y * m_v * Time.deltaTime);*/
    }

    void DeaccelerationFixer()
    {
        if(m_horizontal > 0f)
            negativeX = false;
        else if(m_horizontal < 0f)
            negativeX = true;
        else if(negativeX)
            vx = m_v*-1;
        else 
            vx = m_v;

        if(m_vertical > 0f)
            negativeY = false;
        else if(m_vertical < 0f)
            negativeY = true;
        else if(negativeY)
            vy = m_v*-1;
        else 
            vy = m_v;
    }
}
