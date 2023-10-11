using UnityEngine;

public class Car_Lights : MonoBehaviour
{

        public Material parklight;
        public Material signal_L;
        public Material signal_R;
        public Material break_light;
        public Light left_head;
        public Light right_head;
        bool hazard = false;
        bool signalLeft = false;
        bool signalRight = false;
        // bool isFogLightOn = false;
        int _light = 0;

        bool _blink = false;

    void Start()
    {
        InvokeRepeating("blink", 0f, 0.5f);
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown("l") && _light < 2)
        {
            _light++;
            Debug.Log(_light);
        }
        if(Input.GetKeyDown("o") && _light > 0)
        {
            _light--;
            Debug.Log(_light);
        }

        if(Input.GetKeyDown("q"))
            {
                if(signalRight)
                {
                    signalRight = false;
                }
                signalLeft = !signalLeft;
            }

        if(Input.GetKeyDown("e"))
            {
                if(signalLeft)
                {
                    signalLeft = false;
                }
                signalRight = !signalRight;
            }

        if(Input.GetKeyDown("h"))
        {
            hazard = !hazard;
            if(!hazard)
            {
                signalLeft = true;
                signalRight = true;
            }
            else
            {
                signalLeft = false;
                signalRight = false;
            }
        }

        if(Input.GetButton("Jump"))
        {
            break_light.EnableKeyword("_EMMISSION");
            break_light.SetColor("_EmissionColor", new Color(1.0f, 0f, 0.0f));
            break_light.SetColor("_Color", new Color(1.0f, 0f, 0.0f));
        }
        else
        {
            break_light.DisableKeyword("_EMMISSION");
            break_light.SetColor("_EmissionColor", new Color(0.4f, 0.2f, 0.0f));
            break_light.SetColor("_Color", new Color(0.4f, 0.2f, 0.0f));
        }

        parklights();
        headlights();
        signallights();

    }

    void headlights()
    {
        if(_light == 2)
        {
            right_head.enabled = true;
            left_head.enabled = true;
        }
        else
        {
            right_head.enabled = false;
            left_head.enabled = false;
        }
    }

    void parklights()
    {
            if(_light > 0)
        {
            parklight.EnableKeyword("_EMMISSION");
            parklight.SetColor("_EmissionColor", new Color(1.0f, 0.6f, 0.0f));
            parklight.SetColor("_Color", new Color(1.0f, 0.6f, 0.0f));
        }
        else
        {
            parklight.DisableKeyword("_EMMISSION");
            parklight.SetColor("_EmissionColor", new Color(0.4f, 0.2f, 0.0f));
            parklight.SetColor("_Color", new Color(0.4f, 0.2f, 0.0f));
        }
    }


    void signallights()
    {


        if(signalLeft && _blink)
        {
            signal_L.EnableKeyword("_EMMISSION");
            signal_L.SetColor("_EmissionColor", new Color(1.0f, 0.6f, 0.0f));
            signal_L.SetColor("_Color", new Color(1.0f, 0.6f, 0.0f));
        }
        else
        {
            signal_L.DisableKeyword("_EMMISSION");
            signal_L.SetColor("_EmissionColor", new Color(0.4f, 0.2f, 0.0f));
            signal_L.SetColor("_Color", new Color(0.4f, 0.2f, 0.0f));
        }
        if(signalRight && _blink)
        {
            signal_R.EnableKeyword("_EMMISSION");
            signal_R.SetColor("_EmissionColor", new Color(1.0f, 0.6f, 0.0f));
            signal_R.SetColor("_Color", new Color(1.0f, 0.6f, 0.0f));
        }
        else
        {
            signal_R.DisableKeyword("_EMMISSION");
            signal_R.SetColor("_EmissionColor", new Color(0.4f, 0.2f, 0.0f));
            signal_R.SetColor("_Color", new Color(0.4f, 0.2f, 0.0f));
        }
    }


    void blink()
    {
        _blink = !_blink;
    }
}
