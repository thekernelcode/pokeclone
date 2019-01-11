using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Moving Stats
    [SerializeField]
    float moveSpeed;
    bool isMoving;

    private Animator anim;

    // Combat Chance
    int walkCounter;
    int walkCounter2;
    bool isInCombat;
    float combatTimerRepeatDelay;

    // Cameras
    public GameObject CameraMain;
    public GameObject CameraCombat;

    // UI
    public GameObject combatTextGO;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        combatTimerRepeatDelay = 3f;
        walkCounter2 = Random.Range(5, 750);

    }
   


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) && isInCombat == false)
        {
            InvokeRepeating("CalculateCombatChance", 1f, combatTimerRepeatDelay);
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            isMoving = true;
        }

        if ((Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) && isInCombat == false)
        {
            InvokeRepeating("CalculateCombatChance", 1f, combatTimerRepeatDelay);
            transform.Translate(new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
            isMoving = true;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveZ", Input.GetAxisRaw("Vertical"));

    }

    void CalculateCombatChance()
    {
        if (walkCounter >= walkCounter2)
        {
            walkCounter2 = Random.Range(5, 750);
            walkCounter = 0;
            EnterCombat();
        }
        else
        {
            walkCounter++;
        }
    }

    void EnterCombat()
    {
        Debug.Log("You have entered into COMBAT");
        isInCombat = true;
        CancelInvoke();
        CameraMain.SetActive(false);
        CameraCombat.SetActive(true);

        combatTextGO.gameObject.SetActive(true);
        combatTextGO.GetComponent<Text>().text = "NOW FIGHT";
        
    }

    

}
