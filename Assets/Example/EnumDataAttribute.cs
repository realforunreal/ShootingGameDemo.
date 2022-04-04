using UnityEngine;
using System;

public class EnumDataAttribute : PropertyAttribute
{
    public readonly string[] names;

    public EnumDataAttribute(Type enumType) //enum에서 이름을 가져와 리스트이름 바꾸기
    {
        names = Enum.GetNames(enumType);
    }
}
