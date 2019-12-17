using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Vector3 originalPosition;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
        originalRotation = this.transform.rotation;

        rigidBody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do nothing
                break;

            case "Finish":
                LoadNextScene();
                break;

            default:
                GameReset();
                break;
        }
    }

    private static void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        int maxScene = SceneManager.sceneCountInBuildSettings - 1;

        if (nextScene <= maxScene)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void GameReset()
    {
        SceneManager.LoadScene(0);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) // Thrust while rotating
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioSource.isPlaying) // So it doesnt layer
            {
                audioSource.Play();
            };
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        //rcsThrust = 10f;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        // Cannot rotate both ways at the same time
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; //resume physics control of rotation
    }
}
