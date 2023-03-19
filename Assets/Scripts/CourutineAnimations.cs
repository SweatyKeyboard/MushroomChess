using System.Collections;
using UnityEngine;

public static class CourutineAnimations
{
    private const float _animDuration = 0.5f;
    public static float AnimDuration => _animDuration;

    public static IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
    public static IEnumerator Rotate(GameObject gameObject, float angle, float duration = _animDuration)
    {
        float elapsed = 0;
        Quaternion start = gameObject.transform.rotation;
        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Euler(
                start.eulerAngles + new Vector3(0, angle, 0) * elapsed / duration);
            yield return null;
        }
        StateChanger.Instance.TryChangeState(new StateUnitActing());
    }

    public static IEnumerator Move(GameObject gameObject, Vector3 finishPosition, float duration = _animDuration)
    {
        float elapsed = 0;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 range = finishPosition - startPosition;
        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            gameObject.transform.position = startPosition + range * elapsed / duration;
            yield return null;
        }
        gameObject.transform.position = finishPosition;
        StateChanger.Instance.TryChangeState(new StateUnitActing());
    }

    public static IEnumerator Move(GameObject[] gameObjects, Vector3[] finishPositions, float duration = _animDuration)
    {
        float elapsed = 0;
        Vector3[] startPositions = new Vector3[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            startPositions[i] = gameObjects[i].transform.position;
        }

        Vector3[] ranges = new Vector3[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            ranges[i] = finishPositions[i] - startPositions[i];
        }
        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);

            for (int i = 0; i < gameObjects.Length; i++)
            {
                    gameObjects[i].transform.position = startPositions[i] + ranges[i] * elapsed / duration;
            }
            yield return null;
        }

        for (int i = 0; i < gameObjects.Length; i++)
        {
                gameObjects[i].transform.position = finishPositions[i];
        }
        StateChanger.Instance.TryChangeState(new StateUnitActing());
    }

    public static IEnumerator Jump(GameObject gameObject, Vector3 finishPosition, float jumpHeight, float duration = _animDuration)
    {
        float elapsed = 0;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 range = finishPosition - startPosition;

        float startY = gameObject.transform.position.y;
        float finishY = finishPosition.y;

        float height = Mathf.Max(startY, finishY) - startY + jumpHeight;
        float heightDown = startPosition.y - finishY + height;
        float middle = finishY / (2 * (startY + finishY) / 2);;

        while (elapsed < duration)
        {
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            gameObject.transform.position = startPosition + range * elapsed / duration;

            float progress = elapsed / duration;
            float x = progress;
            if (x < middle)
            {
                x /= middle;
                x = -x * x + 2 * x;
            }
            else
            {
                x = (x - middle) / (1 - middle);
                x = x * x;
            }



            float yPos = 0;
            if (progress < middle)
            { 
                yPos = x * height;
            }
            else
            {
                yPos = height - x * heightDown;
            }

            //float yPos = -4 * jumpProgress * jumpProgress + 4 * jumpProgress;


            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                startY + yPos,
                gameObject.transform.position.z);

            yield return null;
        }
        gameObject.transform.position = finishPosition;
        StateChanger.Instance.TryChangeState(new StateUnitActing());
    }
}