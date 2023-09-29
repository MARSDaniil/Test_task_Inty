using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slider : MonoBehaviour
{
    private RectTransform rectTransform;
    public Slides slides = Slides.aboutProduct;
    [Header("Scroll")]
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] List<Vector2> slidesCoordButton;
    [Space]
    [Header("Switch Car")]
    [SerializeField] Vector2 yCoordinatsOfSwithCars = new Vector2(300, 700);

    [SerializeField] Image car0;
    [SerializeField] Image car1;
    [SerializeField] Image car2;
    [Space]
    [Header("Hood Cover")]

    [SerializeField] Vector2 yCoordinatsOfOpenHood = new Vector2(1780, 2250);
    [SerializeField] RectTransform hoodCover;
    private Vector2 angleOfOpen = new Vector2(42.2f, 0);
    [Space]
    [Header("Magnifying Glass")]
    [SerializeField] Vector2 yCoordinatsOfOpenMagnifyingGlass = new Vector2(740, 1200);
    [SerializeField] RectTransform magnifyingGlass;
    private Vector2 scaleOfOpenMagnifyingGlass = new Vector2(0,30f);
    [Space]
    [Header("Buttons")]
    [SerializeField] Button upBotton;
    [SerializeField] Button downButton;
    [Space]
    [Header("Header Bar")]

    [SerializeField] List<TMP_Text> namesOfSlides;
    [SerializeField] List<Vector2> coordinatsOfSlides;
    [Space]
    [Header("Titles")]
    [SerializeField] List<Animation> titlesListAnim;
    [SerializeField] List<Animation> groupOfObjects;
    public void Init() {
        rectTransform = GetComponent<RectTransform>();
        ChangeCarState(true, false, false);

        hoodCover.transform.eulerAngles = new Vector3(0, 0, angleOfOpen.x);
        magnifyingGlass.localScale = Vector2.zero;

        slides = Slides.aboutProduct;
        if (namesOfSlides.Count > 0) namesOfSlides[0].color = Color.gray;

        upBotton.onClick.AddListener(ScrollToTop);
        downButton.onClick.AddListener(ScrollToBottom);
    }

    // Update is called once per frame
    void Update()
    {
        

        //car switcher
        if (rectTransform.localPosition.y < yCoordinatsOfSwithCars.x
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
        
        //hood cover
        if(rectTransform.localPosition.y > yCoordinatsOfOpenHood.x &&
            rectTransform.localPosition.y < yCoordinatsOfOpenHood.y) {
            float hight = rectTransform.localPosition.y - yCoordinatsOfOpenHood.x;
            float currAngle = -(angleOfOpen.x - angleOfOpen.y)*hight/(yCoordinatsOfOpenHood.y- yCoordinatsOfOpenHood.x)+angleOfOpen.x;
            hoodCover.transform.eulerAngles = new Vector3(0, 0, currAngle);
        }

        //magnifying glass

        if (rectTransform.localPosition.y > yCoordinatsOfOpenMagnifyingGlass.x &&
             rectTransform.localPosition.y < yCoordinatsOfOpenMagnifyingGlass.y) {
            float hight = rectTransform.localPosition.y - yCoordinatsOfOpenMagnifyingGlass.x;
            float currScale = (scaleOfOpenMagnifyingGlass.y - scaleOfOpenMagnifyingGlass.x) * hight 
                / (yCoordinatsOfOpenMagnifyingGlass.y - yCoordinatsOfOpenMagnifyingGlass.x);
            magnifyingGlass.localScale = new Vector2(currScale, currScale);
        }

        
        //colorize top header
        int i = 0;
        while(i < coordinatsOfSlides.Count){

            if(rectTransform.localPosition.y > coordinatsOfSlides[i].x 
                && rectTransform.localPosition.y < coordinatsOfSlides[i].y
                && ((int)slides) != i
                ) {
                int j = 0;

                while(j < namesOfSlides.Count) {
                    namesOfSlides[j].color = Color.white;
                j++;
                }
                namesOfSlides[i].color = Color.gray;

                if ((int)slides < i && i <groupOfObjects.Count-1) {
                    titlesListAnim[i+1].Play();
                    groupOfObjects[i+1].Play();
                }
                slides = (Slides)i;
            }
            i++;
        }

    }

    private void ChangeCarState(bool car0Value, bool car1Value,  bool car2Value) {
        car0.gameObject.SetActive(car0Value);
        car1.gameObject.SetActive(car1Value);
        car2.gameObject.SetActive(car2Value);
    }



    public void ScrollToTop() {

        scrollRect.content.localPosition = slidesCoordButton[0];
     //   slides = (Slides)0;
    }
    public void ScrollToBottom() {
        scrollRect.content.localPosition = slidesCoordButton[slidesCoordButton.Count - 1];
   //     slides = (Slides)3;
    }

    public enum Slides {
        aboutProduct = 0,
        ñhallenge,
        function,
        advantages
    }
}
