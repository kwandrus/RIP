using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;

public class textGradientChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public TextMeshProUGUI txt; 
  
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // When highlighted
        txt.isRightToLeftText = true;
        Debug.Log("im in");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When unhighlighted
        txt.isRightToLeftText = false;
        Debug.Log("im out");
    }

    public void flipText()
    {
        txt.isRightToLeftText = true;
    }

    public void unflipText()
    {
        txt.isRightToLeftText = false;
    }

    public void OnSelect(BaseEventData eventData)
    {
        // When selected -- For you, input man 
    }
}