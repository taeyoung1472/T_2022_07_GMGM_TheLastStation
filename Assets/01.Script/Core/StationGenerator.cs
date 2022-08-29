using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    public int x, y;

    public GameObject block1X1;
    public GameObject block2X1;
    public GameObject block3X1;
    
    [ContextMenu("¤±¤±")]
    public void GenerateStation()
    {
        for (int i = 0; i < y; i++)
        {
            List<int> blockList = new List<int>();
            int total = 0;
            int cur = 0;

            while (total != x)
            {
                int rand = Random.Range(1, 4);
                total += rand;
                if(total > x)
                {
                    total -= rand;
                }
                else
                {
                    blockList.Add(rand);
                }
            }

            foreach (int idx in blockList)
            {
                GameObject obj = null;

                switch (idx)
                {
                    case 1:
                        obj = block1X1;
                        break;
                    case 2:
                        obj = block2X1;
                        break;
                    case 3:
                        obj = block3X1;
                        break;
                }

                Instantiate(obj, new Vector3(cur, i, 0), Quaternion.identity);

                cur += idx;
            }
        }
    }
}
