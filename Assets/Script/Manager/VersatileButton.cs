using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    
    public void Purchase(int price) // ����
    {
        // ������ ����(price)�� GameManager�� �ִ� score���� ũ�ٸ�
        // ���� ũ�ٸ� . ��������
        if(price > GameManager.instance.score)
        {
            // �������� ���ŵ��� �ʰ� �Լ��� ����˴ϴ�.
            return;
        }

        else if (price <= GameManager.instance.score)
        {
            GameManager.instance.score -= price; // ���̰�
            GameManager.instance.dragon++; // ���� ���̰� �巡�� ++ �ǰ�
        }

    }

    public void OpenWindow(GameObject window)// Ȱ��ȭ
    {
        window.SetActive(true);
    }

    public void CloseWindow(GameObject window)// ��Ȱ��ȭ
    {
        window.SetActive(false);
    }


}
