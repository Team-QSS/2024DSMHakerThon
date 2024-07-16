using System.Collections;
using UnityEngine;

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
        private Vector2 mousePos;
        private float mouseDisX;
        private float mouseDisY;

        public bool isAttach;
        // Start is called before the first frame update
        private void Start()
        {
            line.positionCount = 2;
            line.endWidth = line.startWidth = 0.2f;
            line.SetPosition(0,transform.position);
            line.SetPosition(1,silk.position);
            line.useWorldSpace = true;
        }

        // Update is called once per frame
        private void Update()
        {
            line.SetPosition(0,transform.position);
            line.SetPosition(1,silk.position);
            if (Input.GetMouseButtonDown(1) && !isSilkActive)
            {
                silk.position = transform.position;
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
                mouseDir = mainCam.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)) - transform.position;
                isSilkActive = true;
                isLineMax = false;
                silk.gameObject.SetActive(true);

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
