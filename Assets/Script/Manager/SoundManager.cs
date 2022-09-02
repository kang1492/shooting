using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // ��𿡼��� �����Ҽ� �ְ�

    //      ������ҽ� ��������/ �̸� ���ϱ�
    private AudioSource audioSource;

    [SerializeField] AudioClip [] audioClip;
    //              �迭�θ���� / �̸� �����ϱ�

    void Start()
    {   
        if(instance == null)
        {
            instance = this;
            // �ν��Ͻ��� ���̸� �ڱ��ڽ� �ֱ�
        }


        audioSource = GetComponent<AudioSource>();
    }

    // SoundStart()�Լ��� �Ű����� count���� ���� �ٸ� ���尡 ��µ˴ϴ�.
                        // �Ű�����
    public void SoundStart(int count)
    {
        

        //audioSource.clip = audioClip[count]; �ؿ��� �����ؼ� ������ ��
        audioSource.PlayOneShot(audioClip[count]);
        // PlayOneShot() �Լ��� ����� Ŭ���� ���� ���尡 �� �� ȣ��Ǵ� �Լ��Դϴ�.

    }



}
