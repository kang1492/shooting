using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    
    public void Purchase(int price) // 구매
    {
        // 아이템 가격(price)이 GameManager에 있는 score보다 크다면
        // 돈이 크다면 . 점수보다
        if(price > GameManager.instance.score)
        {
            // 아이템이 구매되지 않고 함수가 종료됩니다.
            return;
        }

        else if (price <= GameManager.instance.score)
        {
            GameManager.instance.score -= price; // 깍이게
            GameManager.instance.dragon++; // 돈이 깍이고 드래곤 ++ 되게
        }

    }

    public void OpenWindow(GameObject window)// 활성화
    {
        window.SetActive(true);
    }

    public void CloseWindow(GameObject window)// 비활성화
    {
        window.SetActive(false);
    }


}
