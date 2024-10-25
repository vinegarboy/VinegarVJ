using UnityEngine;
using UniTask;
using UnityEngine.UI;

public class EffecterScript : MonoBehaviour{
    [SerializeField]
    private Material material;

    public void SetMaterial(Material material){
        this.material = material;
    }

}