using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IActionSelectable
{
    bool isActionSelected();
    void unselectAction();
}
