using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // 어디에서도 접근할수 있게

    //      오디오소스 가져오기/ 이름 정하기
    private AudioSource audioSource;

    [SerializeField] AudioClip [] audioClip;
    //              배열로만들기 / 이름 정의하기

    void Start()
    {   
        if(instance == null)
        {
            instance = this;
            // 인스턴스가 널이면 자기자신 넣기
        }


        audioSource = GetComponent<AudioSource>();
    }

    // SoundStart()함수는 매개변수 count값에 따라 다른 사운드가 출력됩니다.
                        // 매개변수
    public void SoundStart(int count)
    {
        

        //audioSource.clip = audioClip[count]; 밑에서 지원해서 지워도 됨
        audioSource.PlayOneShot(audioClip[count]);
        // PlayOneShot() 함수는 오디오 클립에 따라 사운드가 한 번 호출되는 함수입니다.

    }



}
