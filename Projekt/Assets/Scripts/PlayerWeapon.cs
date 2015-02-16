using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    private static PlayerWeapon _currentWeapon;
    public static PlayerWeapon currentWeapon
    {
        get { return _currentWeapon; }
        set
        {
            if(_currentWeapon)
                _currentWeapon.Deactivate();
            _currentWeapon = value;
            _currentWeapon.Activate();
        }
    }

    private Image image;
    public KeyCode keyToSelect;
    public bool startWeapon;
    private const float activeAlpha = 1;
    private const float inactiveAlpha = 0.1f;
    private const float fadeSpeed = 3;
    private float targetAlpha = inactiveAlpha;


    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        if(startWeapon)
        {
            currentWeapon = this;
        }
    }

	void Update()
    {
	    if(Input.GetKeyDown(keyToSelect))
        {
            currentWeapon = this;
        }

        var c = image.color;
        c.a = Mathf.MoveTowards(c.a, targetAlpha, Time.deltaTime * fadeSpeed);
        image.color = c;
	}

    private void Activate()
    {
        targetAlpha = activeAlpha;
        PlayerWeaponSelector.instance.targetPosition = GetComponent<RectTransform>().position;
    }
    private void Deactivate()
    {
        targetAlpha = inactiveAlpha;
    }
}
