using UnityEngine;

public class RandomizeAssetRotation : MonoBehaviour
{
    [Header("Randomize Parameters")]
    [Min(1)][SerializeField] private int overallRotations = 2;
    [Min(1)][SerializeField] private int individualRotations = 2;
    [SerializeField] private bool fixModelAxisRotation = false;

    
    float yRot;

    private void Awake()
    {
        RandomizeAssets();
    }

    [ContextMenu(nameof(RandomizeAssets))]
    private void RandomizeAssets()
    {
        OverallObjectRotation();
        IndividualObjectRotation();
    }

    private void OverallObjectRotation()
    {
        if (overallRotations == 1) return;
        yRot = (360f / overallRotations) * Random.Range(0, overallRotations);
        this.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
    }

    private void IndividualObjectRotation()
    {
        if (individualRotations == 1) return;
        foreach (Transform child in this.transform)
        {
            float xRot = fixModelAxisRotation ? -90f : 0f;
            yRot = (360f / individualRotations) * Random.Range(0, individualRotations);        this.transform.Rotate(0f, yRot, 0f);
            child.rotation = Quaternion.Euler(xRot, yRot, 0f);
        }
    }
}
