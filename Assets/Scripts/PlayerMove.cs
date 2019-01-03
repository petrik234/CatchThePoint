using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public CharacterController playerControl;
    public float moveSpeed;
    public Vector3 moveDirections;
    public bool checkActions;
    public float playerGravity = 20.0f;
    public float vGravity;
    
    void Start()
    {
        checkActions = false;
        playerControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMoving();
    }

    public void PlayerMoving()
    {

        if (Input.anyKey.Equals(false))
        {
            checkActions = false;
        }
        else
        {
            checkActions = true;
        }
        moveDirections = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirections = transform.TransformDirection(moveDirections);
        vGravity -= playerGravity * Time.deltaTime;
        moveDirections.y = vGravity;
        moveDirections *= moveSpeed;
        playerControl.Move(moveDirections * Time.deltaTime);
    }  

}
