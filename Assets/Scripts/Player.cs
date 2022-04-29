using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [Header("Object References")]
  public Rigidbody2D rb;
  public float movementSpeed;

  Vector2 movement;

  void Start()
  {
    rb = this.GetComponent<Rigidbody2D>();

  }

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
  }

  private void FixedUpdate()
  {
    rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {

    if (collision.gameObject.tag == "FirstLayerDestination")
    {
      transform.position = new Vector2(17.6f, -3.51f);
      GameManager.Instance.ChangeState(GameState.SecondLevel);
    }
    if (collision.gameObject.tag == "SecondLayerDestination")
    {
      transform.position = new Vector2(47.6f, -3.51f);
      GameManager.Instance.ChangeState(GameState.ThirdLevel);
    }
    if (collision.gameObject.tag == "ThirdLayerDestination")
    {
      transform.position = new Vector2(92.5f, -3.51f);
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
