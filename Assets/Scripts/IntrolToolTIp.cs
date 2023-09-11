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
    [SerializeField] Image leftArrow;
    [SerializeField] Image rightArrow;
    [SerializeField] Image closeButton;
    // Start is called before the first frame update
    private int currentPage = 1;
    private int maxPage = 3;
    private int minPage = 1;

    void Start()
    {
        UpdatePage();
        Debug.Log(currentPage);
    }

    public void NextImage()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            UpdatePage();
            Debug.Log(currentPage);
        }
    }

    public void PreviousImage()
    {
        if (currentPage > minPage)
        {
            currentPage--;
            UpdatePage();
            Debug.Log(currentPage);
        }
    }

    private void UpdatePage()
    {
        tool1.gameObject.SetActive(currentPage == 1);
        tool2.gameObject.SetActive(currentPage == 2);
        tool3.gameObject.SetActive(currentPage == 3);

        leftArrow.gameObject.SetActive(currentPage > minPage);
        rightArrow.gameObject.SetActive(currentPage < maxPage);
    }

    public void CloseToolTip()
    {
        toolTipPanel.gameObject.SetActive(false);
    }
}
