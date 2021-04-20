using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable<T>
{

    public void pickup(T value);

}
