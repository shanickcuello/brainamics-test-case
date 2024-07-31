using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreManager.Score++;
        Destroy(gameObject);
    }
}