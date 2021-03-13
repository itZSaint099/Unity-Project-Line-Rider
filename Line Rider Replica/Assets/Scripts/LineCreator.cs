using UnityEngine;
using System.Collections;

public class LineCreator : MonoBehaviour
{
    public GameObject[] linePrefabs;

    Line activeLine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int index = 0;
            IEnumerator WaitForLine()
            {
                yield return new WaitForSeconds(5);
                index = ChangeLine();
            }
            index = StartCoroutine(WaitForLine());
            GameObject lineGO = Instantiate(linePrefabs[index]);
            activeLine = lineGO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }

    int ChangeLine()
    {
        int index = Random.Range(0, 3);
        return index;
    }
}
