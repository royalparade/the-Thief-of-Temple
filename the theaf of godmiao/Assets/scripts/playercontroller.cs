using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class playercontroller : MonoBehaviour
{
    public Transform Checkpointr;
    public Transform Checkpointl;
    public Transform Checkpoint;//这个点一般位于主角的脚下
    public float CheckRadius = 0.1f;
    public LayerMask Whatisground;//设置要检测的地面层

    public int faceto = 1;//0huo-1
    public bool inground = true;
    public bool inwall;
    public Canvas end;
    public TMP_Text text1;
    public TMP_Text text2;


    public bool compelete;

    public GameObject eye;

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (faceto == 1)
        {
            eye.transform.DOLocalMoveX(-0.249f, 1f);
        }
        else
        {
            eye.transform.DOLocalMoveX(-0.589f, 1f);
        }

        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            end.gameObject.SetActive(false);
        }

        if (!compelete)
        {
            inground = Physics2D.OverlapCircle(Checkpoint.position, CheckRadius, Whatisground);
            if (Physics2D.OverlapCircle(Checkpointl.position, CheckRadius, Whatisground) || Physics2D.OverlapCircle(Checkpointr.position, CheckRadius, Whatisground))
            {
                inwall = true;
            }
            else
            {
                inwall = false;
            }
            if (inwall)
            {
                if (Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.y) <= 3.5f)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, transform.GetComponent<Rigidbody2D>().velocity.y - 0.01f);
                }

            }
            else
            {
                if (Mathf.Abs(transform.GetComponent<Rigidbody2D>().velocity.x) <= 3.5f)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x + faceto * 0.1f, transform.GetComponent<Rigidbody2D>().velocity.y);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (inground)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x, 4f);
                }
                else if (inwall)
                {
                    faceto = faceto == 1 ? -1 : 1;
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector2(faceto * 3, 4);
                }
            }
            if (transform.position.y <= -6)
            {
                end.gameObject.SetActive(true);
                text1.text = "<color=red>死于坠落";
                text2.text = "按R键再次挑战试炼,按Q键返回菜单";
                Destroy(gameObject);
                compelete = true;
            }
        }        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        if (!compelete)
        {
            switch (collision.transform.name)
            {
                case "ci":
                    end.gameObject.SetActive(true);
                    text1.text = "<color=red>死于尖刺";
                    text2.text = "按R键再次挑战试炼,按Q键返回菜单";
                    compelete = true;
                    break;
                case "spear(Clone)":
                    end.gameObject.SetActive(true);
                    text1.text = "<color=red>死于长矛";
                    text2.text = "按R键再次挑战试炼,按Q键返回菜单";
                    compelete = true;
                    break;
                case "arrow(Clone)":
                    end.gameObject.SetActive(true);
                    text1.text = "<color=red>死于毒箭";
                    text2.text = "按R键再次挑战试炼,按Q键返回菜单";
                    compelete = true;
                    break;
                case "end":
                    end.gameObject.SetActive(true);
                    text1.text = "<color=yellow>破解神庙";
                    text2.text = "按Q键返回菜单";
                    compelete = true;
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }    
    }
}
