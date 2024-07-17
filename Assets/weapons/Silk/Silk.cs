using System.Collections;
using player.script;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace weapons.Silk
{
    public class Silk : MonoBehaviour
    {
        public LineRenderer line;
        public Transform silk;
        
        

        private Vector2 mouseDir;
        public Camera mainCam;
        public bool isSilkActive;
        public bool isLineMax;
        public bool isLineLimit;
        private Vector2 mousePos;
        private float mouseDisX;
        private float mouseDisY;
        public int silkGauge = 6;
        private bool filling;
        [SerializeField] private GameObject[] silkGaugeObj;
        [SerializeField] private Sprite filled;
        [FormerlySerializedAs("spended")] [SerializeField] private Sprite spent;
        private PlayerMove playerMove;
        private Rigidbody2D rb;
        

        public bool isAttach;
        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerMove = gameObject.GetComponent<PlayerMove>();
            line.positionCount = 2;
            line.endWidth = line.startWidth = 0.13f;
            line.SetPosition(0,transform.position);
            line.SetPosition(1,silk.position);
            line.useWorldSpace = true;
        }

        // Update is called once per frame
        private void Update()
        {
            line.SetPosition(0,transform.position);
            line.SetPosition(1,silk.position);
            if (Input.GetMouseButtonDown(1) && !isSilkActive && silkGauge>0)
            {
                silk.position = transform.position;
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                mouseDir = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)) - transform.position;
                isSilkActive = true;
                isLineMax = false;
                silk.gameObject.SetActive(true);
                silkGaugeObj[silkGauge - 1].GetComponent<Image>().sprite = spent;
                silkGauge--;
            }
            switch (isSilkActive)
            {
                case true when !isLineMax:
                {
                    silk.position = Vector2.MoveTowards(silk.position, mousePos,
                        Time.deltaTime * 30);
                    if (Vector2.Distance(transform.position, silk.position) > 9f) isLineMax = true;
                    if (silk.position.Equals(mousePos)) isLineMax = true;

                    if (silk.GetComponent<SilkThrow>().isBlocked) mousePos = silk.GetComponent<SilkThrow>().stopPos;
                    if (silk.GetComponent<SilkThrow>().isGraped) mousePos = silk.GetComponent<SilkThrow>().executePos;

                    break;
                }
                case true when isLineMax && !isAttach:
                {
                    silk.position = Vector2.MoveTowards(silk.position, transform.position, Time.deltaTime * 30);
                    if (Vector2.Distance(transform.position, silk.position) < 0.1f)
                    {
                        isSilkActive = false;
                        isLineMax = false;
                        silk.gameObject.SetActive(false);
                    }
                    break;
                }
                default:
                {
                    if (isAttach)
                    {
                        isLineLimit = Vector2.Distance(transform.position, silk.position) > 9f;
                        if (isLineLimit) rb.position = Vector3.Lerp(transform.position, silk.position, 0.01f);
                        if (Input.GetMouseButtonUp(1))
                        {
                            isAttach = false;
                            isSilkActive = false;
                            isLineMax = false;
                            silk.GetComponent<SilkThrow>().joint2D.enabled = false;
                            silk.gameObject.SetActive(false);
                        }
                    }
                    else if (silk.GetComponent<SilkThrow>().isGraped) StartCoroutine(Execution());
                    break;
                }
            }
            if (!silk.gameObject.activeSelf) silk.gameObject.transform.position = gameObject.transform.position;
        }

        public void Fill()
        {
            if (!filling)
            {
                StartCoroutine(Fill_IE());
            }
        }

        private IEnumerator Fill_IE()
        {
            filling = true;
            while (silkGauge != 6)
            {
                if(!playerMove.IsOnPlatform() && !playerMove.IsGrounded())
                    break;
                yield return new WaitForSeconds(0.5f);
                silkGauge++;
                silkGaugeObj[silkGauge-1].GetComponent<Image>().sprite = filled;
            }

            filling = false;
        }
        private IEnumerator Execution()
        {
            isLineMax = true;
            var player = GameObject.Find("player");
            while (!player.transform.position.Equals(silk.GetComponent<SilkThrow>().executePos))
            {
                player.transform.position = Vector2.MoveTowards(gameObject.transform.position,
                    silk.GetComponent<SilkThrow>().executePos, Time.deltaTime);
                yield return null;
            }
            silk.GetComponent<SilkThrow>().isGraped = false;
            isAttach = false;
            // Pyke.GetComponent<Pyking>().excutePos = Vector2.zero;
            isSilkActive = false;
            isLineMax = false;
            silk.GetComponent<SilkThrow>().joint2D.enabled = false;
            silk.gameObject.SetActive(false);
        }

        
    }
}
