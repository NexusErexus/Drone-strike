using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedFactor = 2.0f;
    float xRange = 10f;
    float yRange = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * speedFactor;
        float yOffset = yThrow * Time.deltaTime * speedFactor;

        float new_X_Pos = transform.localPosition.x + xOffset;
        float new_Y_Pos = transform.localPosition.y + yOffset;

        float clamped_X_Pos = Mathf.Clamp(new_X_Pos, -xRange, xRange);
        float clamped_Y_Pos = Mathf.Clamp(new_Y_Pos, -yRange, yRange);
        transform.localPosition = new Vector3(clamped_X_Pos, clamped_Y_Pos, transform.localPosition.z);
    }
}
