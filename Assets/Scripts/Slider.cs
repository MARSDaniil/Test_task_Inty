using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider : MonoBehaviour
{
    public Vector2 yCoordinatsOfSwithCars = new Vector2(300, 700);

    public Image car0;
    public Image car1;
    public Image car2;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ChangeCarState(true, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(rectTransform.localPosition.y < yCoordinatsOfSwithCars.x
            && car0.gameObject.activeSelf == false) {
            ChangeCarState(true, false, false);
        }
        else if (rectTransform.localPosition.y > yCoordinatsOfSwithCars.x 
            && rectTransform.localPosition.y < yCoordinatsOfSwithCars.y 
            && car1.gameObject.activeSelf == false)
        {
            ChangeCarState(false, true, false);
        }
        else if(rectTransform.localPosition.y > yCoordinatsOfSwithCars.y
            && car2.gameObject.activeSelf == false) {
            ChangeCarState(false, false, true);
        }


    }

    private void ChangeCarState(bool car0Value, bool car1Value,  bool car2Value) {
        car0.gameObject.SetActive(car0Value);
        car1.gameObject.SetActive(car1Value);
        car2.gameObject.SetActive(car2Value);

    }
}
