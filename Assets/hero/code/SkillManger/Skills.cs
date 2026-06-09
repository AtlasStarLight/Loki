using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   enum SkillType
{
    Giant,
    Clone,
    Dodge,
    Magic,
    Partner,
    Bagger
}
public class Skills : MonoBehaviour
{
 public SkillType skillType;
}
