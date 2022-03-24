using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    [SerializeField]
    private float horizontal_input;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float penalty = 0.5f;

    [SerializeField]
    private int lvl;

    [SerializeField]
    private Vector2 jump;

    private float jumpforce = 2.0f;

    public bool isgrounded;

    Rigidbody2D rb;

    private UI_manager UIManager;
    private GameManager _gamemanager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);

        UIManager = GameObject.Find("Canvas").GetComponent<UI_manager>();
        _gamemanager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _gamemanager.currnetlvl(lvl);
        UIManager.current_level(lvl);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isgrounded = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _gamemanager.restart();
        }

        player_movement();
        jumping();
    }

    private void jumping()
    {
        if(Input.GetKey(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(jump * jumpforce, ForceMode2D.Impulse);
            isgrounded = false;
        }
    }

    private void player_movement()
    {
        horizontal_input = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.LeftShift) == true)
        {
            rb.AddForce(new Vector3(horizontal_input * penalty * speed * Time.deltaTime, 0.0f, 0.0f));
            Vector3 direction = new Vector3(horizontal_input, 0, 0);
            transform.Translate(direction * speed * 0.5f * Time.deltaTime);
        }
        else
        {
            rb.AddForce(new Vector3(horizontal_input * speed * Time.deltaTime, 0.0f, 0.0f));
            Vector3 direction = new Vector3(horizontal_input, 0, 0);
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "death" || other.tag == "spikes")
        {
            UIManager.gameover();
            UIManager.restart();
            Destroy(this.gameObject);
        }

        if(other.tag == "end")
        {
            if (lvl == 3)
            {
                UIManager.gamecompleted();
                Destroy(this.gameObject);
            }else
            {
                _gamemanager.next_lvl(lvl + 1);
            }
            
        }
    }
}
