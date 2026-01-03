using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField]
    [Header("List of all screens")]
    private List<GameObject> m_pages;

    [SerializeField]
    [Header("Start screen name")]
    private string m_startScreenName;

    private GameObject m_currentPage;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_pages = new List<GameObject>();

        foreach (GameObject page in m_pages)
        {
            if (page.name.Equals(m_startScreenName))
                continue;

            page.SetActive(false);
        }
    }

    /// <summary>
    /// Activate the propriate page
    /// </summary>
    /// <param name="screenName"></param>
    public void ShowScreen(string screenName)
    {
        foreach (var p in m_pages)
        {
            p.SetActive(p.name == screenName);
        }
    }

    /// <summary>
    /// Activate the propriate page using index
    /// </summary>
    /// <param name="index"></param>
    public void ShowScreenByIndex(int index)
    {
        for (int i = 0; i < m_pages.Count; i++)
        {
            m_pages[i].SetActive(i == index);
        }
    }
}
