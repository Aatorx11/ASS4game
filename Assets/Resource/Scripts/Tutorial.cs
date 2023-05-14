using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public MonoBehaviour PlayerController1;
    public MonoBehaviour BlueSquareGenerator ;
    public MonoBehaviour PlayerOtherControllerCHANGE;
    public MonoBehaviour PlayerController3 ;

    private void Start()
    {
        // Initially disable all scripts
        PlayerController1.enabled = true;
        BlueSquareGenerator .enabled = false;
        PlayerOtherControllerCHANGE.enabled = false;
        PlayerController3.enabled = false;
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Enable PlayerController1 and disable others
            PlayerController1.enabled = true;
            BlueSquareGenerator .enabled = false;
            PlayerOtherControllerCHANGE.enabled = false;
            PlayerController3.enabled = false;
        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Enable BlueSquareGenerator  and disable others
            PlayerController1.enabled = true;
            BlueSquareGenerator .enabled = true;
            PlayerOtherControllerCHANGE.enabled = false;
            PlayerController3.enabled = false;
        
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // Enable PlayerOtherControllerCHANGE and disable others
            PlayerController1.enabled = true;
            BlueSquareGenerator .enabled = false;
            PlayerOtherControllerCHANGE.enabled = true;
            PlayerController3.enabled = false;
          
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Enable PlayerController3 and disable others
            PlayerController1.enabled = false;
            BlueSquareGenerator .enabled = false;
            PlayerOtherControllerCHANGE.enabled = false;
            PlayerController3.enabled = true;
         
        }
         else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // Enable PlayerController3 and disable others
            PlayerController1.enabled = true;
            BlueSquareGenerator .enabled = false;
            PlayerOtherControllerCHANGE.enabled = false;
            PlayerController3.enabled = false;
           
        }
    }
}
