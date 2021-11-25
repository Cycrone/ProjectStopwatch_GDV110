using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;

    public GameObject g;
    public Tutorial_GrapplingRope grappleRope;
    public Rigidbody2D m_rigidbody;
    public SpringJoint2D m_springJoint2D;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (g.activeInHierarchy == false)
        {  
            grappleRope.enabled = false;
            m_rigidbody.gravityScale = 3;
            m_springJoint2D.enabled = false;
        }
        int previousSelectedWeapon = selectedWeapon;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }
            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
        
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
