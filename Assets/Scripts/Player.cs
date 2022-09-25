﻿using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private SpriteRenderer spriteRender;
    public Sprite[] sprites;
    private int spriteIndex;
    [SerializeField]private GameManager ruler;
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();   
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up*strength;
        }
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex>=sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRender.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            ruler.GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            ruler.IncreaseScore();
        }
    }
   
}
