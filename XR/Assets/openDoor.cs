using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour
{
    #region Public Variables
    public float rotationY = 90f;
    public float openDuration = 2f;
    public Vector3 targetPosition = new Vector3(1.24f, 0f, 0f);
    #endregion

    #region Private Variables
    private bool isOpen = false;
    private bool isMoving = false;

    private Quaternion initialRotation;
    private Vector3 initialPosition;
    #endregion

    #region Unity Callbacks
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotation = transform.rotation;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods
    public void ToggleDoor()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveDoorGradually());
        }
    }
    #endregion

    #region Private Methods
    private IEnumerator MoveDoorGradually()
    {
        isMoving = true;

        Quaternion startRotation = transform.rotation;
        Vector3 startPosition = transform.position;

        Quaternion endRotation = isOpen ? initialRotation : initialRotation * Quaternion.Euler(0f, rotationY, 0f);
        Vector3 endPosition = isOpen ? initialPosition : new Vector3(initialPosition.x + targetPosition.x, initialPosition.y, initialPosition.z);

        float elapsedTime = 0f;

        while (elapsedTime < openDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / openDuration;

            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.rotation = endRotation;
        transform.position = endPosition;

        isOpen = !isOpen;
        isMoving = false;
    }
    #endregion
}
