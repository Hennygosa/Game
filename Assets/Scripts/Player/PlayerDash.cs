using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Rigidbody rb;
    public RadialBar radialBar;
    public GameObject movementScript;

    public int dashSpeed = 100;
    public float dashCooldown = 2f;
    public float dashDuration = 0.5f;

    private bool isDashing = false;
    private float timer;
    private void Start()
    {
        timer = 0;
        radialBar.maxValue = dashCooldown;
        radialBar.amount.text = $"{dashCooldown}";
    }
    private void Update()
    {
        //выкл скрипт на движение во время рывка
        if (!isDashing)
            movementScript.GetComponent<PlayerMovement>().enabled = true;
        //обновляем индикатор кд
        if (timer > 0)
        {
            radialBar.amount.enabled = true;
            timer -= Time.deltaTime;
            radialBar.Modify(timer);
            radialBar.amount.text = $"{Mathf.CeilToInt(timer)}";
            return;
        }
        //если нет кд - рывок
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
            movementScript.GetComponent<PlayerMovement>().enabled = false;
            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.z = Input.GetAxisRaw("Vertical");
            rb.AddForce(direction.normalized * dashSpeed * Time.deltaTime, ForceMode.VelocityChange);
            yield return new WaitForSeconds(dashDuration);
            isDashing = false;

        }
    }
}
