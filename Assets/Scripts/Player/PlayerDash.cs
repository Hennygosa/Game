using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject movementScript;

    public int dashSpeed = 100;
    public float dashCooldown = 2f;
    public float dashDuration = 0.5f;

    private RadialBar radialBar;
    private bool isDashing = false;
    private float timer;
    private void Start()
    {
        radialBar = GameObject.Find("Dash").GetComponent<RadialBar>();
        timer = 0;
        radialBar.maxValue = dashCooldown;
        radialBar.amount.text = $"{dashCooldown}";
    }
    private void Update()
    {
        //���� ������ �� �������� �� ����� �����
        if (isDashing)
            movementScript.GetComponent<PlayerMovement>().enabled = false;
        else
            movementScript.GetComponent<PlayerMovement>().enabled = true;
        //��������� ��������� ��
        if (timer > 0)
        {
            radialBar.amount.enabled = true;
            timer -= Time.deltaTime;
            radialBar.Modify(timer);
            radialBar.amount.text = $"{Mathf.CeilToInt(timer)}";
            return;
        }
        //���� ��� �� - �����
        if (timer <= 0)
        {
            radialBar.Modify(dashCooldown);
            radialBar.amount.enabled = false;
            StartCoroutine(Dash());

        }

    }

    IEnumerator Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 2f;
            isDashing = true;
            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
            rb.AddForce(direction.normalized * dashSpeed * Time.deltaTime, ForceMode.VelocityChange);
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;
        }
    }
}