using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float speed; //배경들이 움직일 속도를 정의해줌
    public Transform[] backgrounds; // 배경들의 배열
 
    float endPosX = 0f; // 배경 끝 x 좌표
    float startPosX = 0f; // 배경 시작 x 좌표
    float xHalfScreen; // 게임화면의 x 좌표 절반
    float yHalfScreen; // 게임화면의 y 좌표 절반

    void Start() //배경을 움직일 때 사용되는 화면 좌표의 값들을 초기화
    {
        resetPos();
    }
    void Update() //실질적 구현 코드
    {
       BackgroundMove();
    }

    private void resetPos() {
        yHalfScreen = Camera.main.orthographicSize;
        xHalfScreen = yHalfScreen * Camera.main.aspect;
 
        endPosX = -xHalfScreen;
        startPosX = xHalfScreen * backgrounds.Length;
    }

    private void BackgroundMove() {

        for(int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;
 
            if(backgrounds[i].position.x < endPosX) // 이동 중 배경의 x좌표가 leftPosX보다 작아지면, 배경에 x좌표에 rightposX만큼 이동시켜줌
            {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + startPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
