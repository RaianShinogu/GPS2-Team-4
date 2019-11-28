using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{

    public GameObject radiusVisualizer;
    public Vector3 localEuler;

    // Start is called before the first frame update
    void Start()
    {
        SetupRadiusVisualizers(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupRadiusVisualizers(GameObject newParent)
    {
        Instantiate(radiusVisualizer);
            radiusVisualizer.SetActive(true);
        radiusVisualizer.transform.SetParent(newParent.transform);
        radiusVisualizer.transform.localPosition = new Vector3(0, 0.01f, 0) ;
            radiusVisualizer.transform.localScale = Vector3.one * 2.0f * 2.0f;
            radiusVisualizer.transform.localRotation = new Quaternion { eulerAngles = localEuler };

            var visualizerRenderer = radiusVisualizer.GetComponent<Renderer>();
            if (visualizerRenderer != null)
            {
                //visualizerRenderer.material.color = provider.effectColor;
            }
        
    }
}
