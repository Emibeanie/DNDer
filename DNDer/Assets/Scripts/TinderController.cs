using UnityEngine;
using UnityEngine.SceneManagement;

public class TinderController : MonoBehaviour
{
    //array of tinder profile sprites
    public SpriteRenderer[] sprites;
    //SFX
    public AudioSource audioSource;
    public AudioClip swipeRightSound;
    public AudioClip swipeLeftSound;

    public float swipeThreshold = 50f;
    public float swipeSpeed = 10f;

    private Vector2 startSwipePos;
    private Vector2 endSwipePos;

    SceneMemoryScript sceneMemory;
    
    public void Start()
    {
        sceneMemory = GameObject.FindAnyObjectByType<SceneMemoryScript>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startSwipePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endSwipePos = Input.mousePosition;

            float swipeDistance = (endSwipePos - startSwipePos).magnitude;

            if (swipeDistance > swipeThreshold)
            {
                bool swipeRight = endSwipePos.x - startSwipePos.x > 0;
                bool swipeLeft = endSwipePos.x - startSwipePos.x < 0;
                
                float swipeDirection = Mathf.Sign(endSwipePos.x - startSwipePos.x);

                if (swipeRight)
                {
                    int highest = -1;
                    int highestIndex = -1;
                    for(int i = 0; i < sprites.Length; i++)
                    {
                        if (highest < sprites[i].sortingOrder)
                        {
                            highest = sprites[i].sortingOrder;
                            highestIndex = i;
                        }
                    }
                    sceneMemory.character_index = highestIndex;
                    
                    audioSource.PlayOneShot(swipeRightSound);
                    SceneManager.LoadScene("Fight");
                }
                else if (swipeLeft)
                {
                    audioSource.PlayOneShot(swipeLeftSound);
                    // swipe left - move current front sprite to the back
                    SpriteRenderer frontSpriteRenderer = null;
                    int frontSpriteIndex = -1;
                    for (int i = 0; i < sprites.Length; i++)
                    {
                        if (frontSpriteRenderer == null || sprites[i].sortingOrder > frontSpriteRenderer.sortingOrder)
                        {
                            frontSpriteRenderer = sprites[i];
                            frontSpriteIndex = i;
                        }
                    }

                    if (frontSpriteRenderer != null)
                    {
                        // Move the front sprite to the back
                        frontSpriteRenderer.sortingOrder = 0;

                        // Move the other sprites forward
                        for (int i = 0; i < sprites.Length; i++)
                        {
                            if (i != frontSpriteIndex)
                            {
                                sprites[i].sortingOrder++;
                            }
                        }

                        
                    }
                }
            }
        }

    }
}
