using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StimDropdown : MonoBehaviour {

    private Dropdown d;
    private Dropdown Dropdown
    {
        get
        {
            if (d == null)
            {
                d = gameObject.GetComponent<Dropdown>();
            }
            return d;
        }
    }

	// Use this for initialization
	void Start () {
       var x = Enumerable.AsEnumerable(Enum.GetNames(typeof(StimulusGenus))).Select(n => new Dropdown.OptionData(n)).ToList();
       Dropdown.options = x;
    }
}
