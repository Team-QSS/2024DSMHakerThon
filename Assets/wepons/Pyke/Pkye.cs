using System.Collections;
using UnityEngine;

namespace wepons.Pyke
{
    public class Pkye : MonoBehaviour
    {
        public LineRenderer line;
        public Transform Pyke;

        private Vector2 mousedir;
        public Camera maincam;
        public bool isPykeActive;
        public bool isLineMax;
        private Vector2 mousepos;
        private float mousedisx;
        private float mousedisy;

        public bool isAttach;
        // Start is called before the first frame update
        private void Start()
        {
            line.positionCount = 2;
            line.endWidth = line.startWidth = 0.2f;
            line.SetPosition(0,transform.position);
            line.SetPosition(1,Pyke.position);
            line.useWorldSpace = true;
        }

        // Update is called once per frame
        private void Update()
        {
            line.SetPosition(0,transform.position);
            line.SetPosition(1,Pyke.position);
            if (Input.GetMouseButtonDown(1) && !isPykeActive)
            {
                Pyke.position = transform.position;
                mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
                mousedir = maincam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                isPykeActive = true;
                isLineMax = false;
                Pyke.gameObject.SetActive(true);

            }

            switch (isPykeActive)
            {
                case true when !isLineMax:
                {
                    Pyke.position = Vector2.MoveTowards(Pyke.position, mousepos,
                        Time.deltaTime * 30);
                    if (Vector2.Distance(transform.position, Pyke.position) > 9f) isLineMax = true;
                    if (Pyke.position.Equals(mousepos)) isLineMax = true;

                    if (Pyke.GetComponent<Pyking>().isBlocked) mousepos = Pyke.GetComponent<Pyking>().stopPos;
                    if (Pyke.GetComponent<Pyking>().isGraped) mousepos = Pyke.GetComponent<Pyking>().excutePos;

                    break;
                }
                case true when isLineMax && !isAttach:
                {
                    Pyke.position = Vector2.MoveTowards(Pyke.position, transform.position, Time.deltaTime * 30);
                    if (Vector2.Distance(transform.position, Pyke.position) < 0.1f)
                    {
                        isPykeActive = false;
                        isLineMax = false;
                        Pyke.gameObject.SetActive(false);
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
                            isPykeActive = false;
                            isLineMax = false;
                            Pyke.GetComponent<Pyking>().joint2D.enabled = false;
                            Pyke.gameObject.SetActive(false);
                        }
                    }
                    else if (Pyke.GetComponent<Pyking>().isGraped) StartCoroutine(Execution());
                    break;
                }
            }
            if (!Pyke.gameObject.activeSelf) Pyke.gameObject.transform.position = gameObject.transform.position;
        }

        private IEnumerator Execution()
        {
            isLineMax = true;
            var player = GameObject.Find("player");
            while (!player.transform.position.Equals(Pyke.GetComponent<Pyking>().excutePos))
            {
                player.transform.position = Vector2.MoveTowards(gameObject.transform.position,
                    Pyke.GetComponent<Pyking>().excutePos, Time.deltaTime);
                yield return null;
            }
            Pyke.GetComponent<Pyking>().isGraped = false;
            isAttach = false;
            // Pyke.GetComponent<Pyking>().excutePos = Vector2.zero;
            isPykeActive = false;
            isLineMax = false;
            Pyke.GetComponent<Pyking>().joint2D.enabled = false;
            Pyke.gameObject.SetActive(false);
        }
    }
}
