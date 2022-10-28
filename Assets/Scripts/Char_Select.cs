using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Char_Select : MonoBehaviour
{

    public GameObject charaConfirmBtn, charaConfirmCloseBtn;

    public void CharaConfirm(GameObject confirmBtn)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(confirmBtn);
    }

    public void CharaConfirmClose()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(charaConfirmCloseBtn);
    }

    

}
