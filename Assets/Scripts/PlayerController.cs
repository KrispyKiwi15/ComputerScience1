using UnityEngine;
public class PlayerController : MonoBehaviour
{

    // Movement variables
    public bool overworld;
    public float xSpeed = 4;
    public float ySpeed = 4;
    float xVector;
    float xDirection;
    float yDirection;
    float yVector;


    void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld;
        xDirection = 0;
        yDirection = 0;
        xVector = 0;
        yVector = 0;
        


    }
    void Update()
    {
        if (overworld)
        {
            yVector = ySpeed * yDirection;
            yDirection = Input.GetAxis("Vertical");
        }

        xDirection = Input.GetAxis("Horizontal");
        xVector = xSpeed * xDirection;
        transform.Translate(xVector * Time.deltaTime, yVector * Time.deltaTime, 0);
        
    }
    void FixedUpdate()
    {
        
    }
}