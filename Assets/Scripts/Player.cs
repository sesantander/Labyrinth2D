using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [Header("Object References")]
  public Rigidbody2D rb;
  public float movementSpeed;

  Vector2 movement;

  public float moveSpeed = 5f;
  public Transform movePoint;
  public LayerMask Wall;

  void Start()
  {
    // rb = this.GetComponent<Rigidbody2D>();
    movePoint.parent = null;
  }

  void Update()
  {
    // movement.x = Input.GetAxisRaw("Horizontal");
    // movement.y = Input.GetAxisRaw("Vertical");


    float movementAmout = moveSpeed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

    if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
    {
      if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
      {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, Wall))
        {
          movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
      }
      if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
      {
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, Wall))
        {
          movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
      }
    }
  }

  private void FixedUpdate()
  {
    // rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {

    if (collision.gameObject.tag == "FirstLayerDestination")
    {
      transform.position = new Vector2(17.6f, -3.51f);
      movePoint.position = new Vector3(17.6f, -3.51f, 0f);
      GameManager.Instance.ChangeState(GameState.SecondLevel);
    }
    if (collision.gameObject.tag == "SecondLayerDestination")
    {
      transform.position = new Vector2(47.6f, -3.51f);
      movePoint.position = new Vector3(47.6f, -3.51f, 0f);
      GameManager.Instance.ChangeState(GameState.ThirdLevel);
    }
    if (collision.gameObject.tag == "ThirdLayerDestination")
    {
      transform.position = new Vector2(92.5f, -3.51f);
      movePoint.position = new Vector3(92.5f, -3.51f, 0f);
      GameManager.Instance.ChangeState(GameState.FourthLevel);
    }
    if (collision.gameObject.tag == "FourthLayerDestination")
    {
      GameManager.Instance.ChangeState(GameState.Win);
    }
    if (collision.gameObject.tag == "Enemy")
    {
      GameManager.Instance.ChangeState(GameState.Lose);
    }
  }
}
