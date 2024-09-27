using player.script;
using SaveAndLoad;
using UnityEngine;

namespace Abilities.OrbItem
{
    public class TheOrb : MonoBehaviour
    {
        private ConsumableItem consumableItem;
        private Rigidbody2D rb;
        private GameObject descriptionText;
        private void Start()
        {
            consumableItem = transform.parent.GetComponent<ConsumableItem>();
            rb = GetComponent<Rigidbody2D>();
            descriptionText = consumableItem.descriptionText;
            if (!SaveData.HasAbilities(consumableItem.ability)) return;
            if (descriptionText) descriptionText.SetActive(false);
            Destroy(consumableItem.gameObject);
        }

        private void Update()
        {
            transform.eulerAngles += new Vector3(0f, 0f, 30f * Time.deltaTime);
            if (!consumableItem.Consume) return;
            var force = PlayerMove.playerPos - rb.position;
            var rot = new Quaternion(force.x, force.y, 0, force.magnitude).eulerAngles;
            rot.z -= 160f;
            var qt = Quaternion.Euler(rot);
            rb.velocity = new Vector2(qt.x, qt.y) * (force.magnitude * 15);
            if ((PlayerMove.playerPos - rb.position).magnitude >= 0.5f) return;
            PlayerMove.canmove = true;
            Destroy(consumableItem.gameObject);
        }
    }
}
