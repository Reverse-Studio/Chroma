using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Transform player;
    // public Slider slider;
    // public float maxHp = 100f;
    // public float currenthp;
    // public Image HPbar;
    private Player pInfo; // 플레이어의 스크립트가 저장될 변수.
    public float score = 0f;
    public Text Score;

    void Update()
    {
        // slider.value = currenthp / maxHp;
        Score.text = "Score : " + (int)score;
    }

    // private void Damage(float damage)
    // {
    //     if (currenthp > 0)
    //     {
    //         currenthp -= damage;
    //         HPbar.fillAmount = currenthp / 100f;
    //     }
    // }
    
    void OnTriggerEnter(Collider col)
    {
        // if (col.tag == "enemy" || col.tag == "obstacle") {
        //     Damage(1f);
        // }
        // if (col.transform.CompareTag("Player"))
        // {
        //     // 플레이어의 스크립트 컴포넌트를 가져온다.
        //     pInfo = col.GetComponent<Player>();
        //     StartCoroutine("StartDamage");
        // }
        if (col.tag == "note") {
            score += 20000f;
        }
    }

    void OnTriggerExit(Collider col)
    {
        // if (col.transform.CompareTag("Player"))
        // {
        //     StopCoroutine("StartDamage");

        //     // 충돌이 끝난 후 정보를 플레이어의 정보를 게속 가지고 있을 필요가
        //     // 없기 때문에 null로 초기화 해준다.
        //     pInfo = null;
        // }
    }

}
