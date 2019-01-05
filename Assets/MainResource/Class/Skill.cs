using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {
    public virtual void Use() { }
}

public class Dash : Skill
{
    public override void Use()
    {
        base.Use();
    }
}

public static class SkillManager
{
    private static Dictionary<uint, Skill> _sklChart;

    static SkillManager()
    {
        _sklChart = new Dictionary<uint, Skill>
        {
            { 1, new Dash()}
        };
    }


    public static Skill GetSkill(uint id)
    {
        Skill skl = new Skill();
        _sklChart.TryGetValue(id, out skl);
        return skl;
    }
}
