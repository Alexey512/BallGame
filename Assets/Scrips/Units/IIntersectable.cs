using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Units
{
    public interface IIntersectable
    {
        bool IsIntersect(Ray ray);
    }
}
