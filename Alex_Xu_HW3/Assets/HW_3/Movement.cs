  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] public float speed = 3.0f;
    [SerializeField] private Sprite[] walkSprites;
    [SerializeField] private float animationSpeed = 0.2f;

    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentSprite = 0;
    
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveObject(){
      if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))){
            
            if(Input.GetKey(KeyCode.A)){
                transform.Translate((Vector2.left * Time.deltaTime) * speed);
            }
            if(Input.GetKey(KeyCode.D)){
                transform.Translate((Vector2.right * Time.deltaTime) * speed);
            }
            if(Input.GetKey(KeyCode.W)){
                transform.Translate((Vector2.up * Time.deltaTime) * speed);
            }
            if(Input.GetKey(KeyCode.S)){
                transform.Translate((Vector2.down * Time.deltaTime) * speed);
            }
       } else {
            timer = 0;
            currentSprite = 0;
       }

       if(Input.GetKey(KeyCode.Space)){
            currentSprite = 4;
       } 
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();

        timer += Time.deltaTime;
        if (timer > animationSpeed){
            timer = 0;
            currentSprite ++;
            currentSprite %= walkSprites.Length - 1;    
        }

        spriteRenderer.sprite = walkSprites[currentSprite];
    }
}
