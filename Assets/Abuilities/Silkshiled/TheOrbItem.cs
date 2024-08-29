
using player.script;
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles += new Vector3(0f,0f,30f*Time.deltaTime);
        if (!ParryItem.consume) return;
            transform.position = Vector2.MoveTowards(transform.position, PlayerMove.playerPos, 0.3f * Time.deltaTime);
            if (new Vector2(transform.position.x, transform.position.y) != PlayerMove.playerPos) return;
            PlayerMove.canmove = true;
            Destroy(gameObject);

    }
}
