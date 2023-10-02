using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedFactor = 18.0f;
    float xRange = 10f;
    float yRange = 8f;
    [SerializeField] float positionPitchFactor = -2.0f;
    [SerializeField] float controlPitchFactor = -15.0f;
    [SerializeField] float positionYawFactor = -.3f;
    [SerializeField] float controlRollFactor = -30.0f;
    [SerializeField] float rotationFactor = 3.0f;
    [SerializeField] GameObject[] lasers;
    [SerializeField] ParticleSystem[] particleSystemToDisable;
    
    float xThrow;
    float yThrow;

    ParticleSystem emission;
    //private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        foreach (var p in particleSystemToDisable)
        {
            if (p != null)
            {
                p.Stop();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * speedFactor;
        float yOffset = yThrow * Time.deltaTime * speedFactor;

        float new_X_Pos = transform.localPosition.x + xOffset;
        float new_Y_Pos = transform.localPosition.y + yOffset;

        float clamped_X_Pos = Mathf.Clamp(new_X_Pos, -xRange, xRange);
        float clamped_Y_Pos = Mathf.Clamp(new_Y_Pos, -yRange, yRange + 2);
        transform.localPosition = new Vector3(clamped_X_Pos, clamped_Y_Pos, transform.localPosition.z);
    }

    public void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControl = xThrow * controlRollFactor;
        float roll = rollDueToControl;
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
    }

    public void FiringLasers(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            Debug.Log("Fire");
            EnableFire();
        }
        else
            DisableFire();
    }

    public void EnableFire()
    {
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(true);
            emission = laser.GetComponent<ParticleSystem>();
            emission.Play();
        }
    }
    public void DisableFire()
    {
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(false);
            
            emission = laser.GetComponent<ParticleSystem>();
            emission.Stop();
        }
    }
}
