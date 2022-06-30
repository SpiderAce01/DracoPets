using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public string pieceStatus = "";
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector3 originalPos;
    public ButtonController pC;

    public AudioSource grabPiece;
    public AudioSource placePiece;
    public AudioSource wrongPiece;

    public bool canPlay = true;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            placePiece.Play();
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            pC.pieceCounter++;
        }
    }

    void OnMouseDown()
    {
        grabPiece.Play();
        canPlay = false;
        originalPos = transform.position;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseUp()
    {
        if(pieceStatus != "locked")
        {
            wrongPiece.Play();
            canPlay = true;
            transform.position = originalPos;
        }
    }

    void OnMouseDrag()
    {
        if (pieceStatus != "locked")
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
}
