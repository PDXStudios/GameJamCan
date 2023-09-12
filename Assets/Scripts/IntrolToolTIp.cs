using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntrolToolTIp : MonoBehaviour
{
    [SerializeField] Image toolTipPanel;
    [SerializeField] Image tool1;
    [SerializeField] Image tool2;
    [SerializeField] Image tool3;
    [SerializeField] Image tool4;
    [SerializeField] Image leftArrow;
    [SerializeField] Image rightArrow;
    [SerializeField] Image closeButton;
    // Start is called before the first frame update
    private int currentPage = 1;
    private int maxPage = 4;
    private int minPage = 1;

    void Start()
    {
        UpdatePage();
    }

    public void NextImage()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            UpdatePage();
        }
    }

    public void PreviousImage()
    {
        if (currentPage > minPage)
        {
            currentPage--;
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        tool1.gameObject.SetActive(currentPage == 1);
        tool2.gameObject.SetActive(currentPage == 2);
        tool3.gameObject.SetActive(currentPage == 3);
        tool4.gameObject.SetActive(currentPage == 4);

        leftArrow.gameObject.SetActive(currentPage > minPage);
        rightArrow.gameObject.SetActive(currentPage < maxPage);
    }

    public void CloseToolTip()
    {
        toolTipPanel.gameObject.SetActive(false);
    }

}
