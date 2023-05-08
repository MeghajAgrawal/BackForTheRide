using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Menu : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    // Start is called before the first frame update
    [SerializeField] private Image img;
    [SerializeField] private Sprite unpressed,pressed;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.sprite = unpressed;
    }
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
