using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class EffecterScript : MonoBehaviour{
    [SerializeField]
    private Material material;

    public void SetMaterial(Material material){
        this.material = material;
    }

    public async void Swipe(){

    }
}