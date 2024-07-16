using UnityEngine;

namespace weapons.Silk
{
    public class SilkThrow : MonoBehaviour
    {
        private Silk silkThrow;
        public SpringJoint2D joint2D;
        public Vector2 stopPos;
        public bool isBlocked;
        public Vector2 executePos;
        public bool isGraped;
        public GameObject particle;
        // Start is called before the first frame update
        private void Start()
        {
            silkThrow = GameObject.Find("player").GetComponent<weapons.Silk.Silk>();
            joint2D = GetComponent<SpringJoint2D>();
            stopPos = Vector2.zero;
            executePos = Vector2.zero;
            isBlocked = false;
            isGraped = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("wall"))
            {
                joint2D.enabled = true;
                silkThrow.isAttach = true;
                isBlocked = true;
                stopPos = gameObject.transform.position;
                Destroy(Instantiate(particle, gameObject.transform.position, Quaternion.Euler(0, 0, 0)),2f);
            }
            else if (collision.CompareTag("enemy"))
            {
                joint2D.enabled = true;
                isGraped = true;
                executePos = gameObject.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("wall")) return;
            isBlocked = false;
            stopPos = Vector2.zero;
            isGraped = false;
        }
    }
}
