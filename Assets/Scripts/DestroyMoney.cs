using UnityEngine;

public class DestroyMoney : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.name == "DestroyArea")
            Destroy(gameObject);
    }
}