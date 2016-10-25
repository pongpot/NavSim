using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCSE.Simulator
{
    class AptBinding
    {
        public List<RpuBinding> _RpuBinding { get; set; }
        public List<RwyBinding> _RwyBinding { get; set; }

        public void AptGetData()
        {
            foreach(RpuBinding rpu in _RpuBinding)
            {
                rpu.RpuGetStatus();
            }
            foreach(RwyBinding rwy in _RwyBinding)
            {
                rwy.RwyGetStatus();
            }
        }
        public void AptSetData()
        {
            foreach(RpuBinding rpu in _RpuBinding)
            {
                rpu.RpuSetStatus();
            }
            foreach(RwyBinding rwy in _RwyBinding)
            {
                rwy.RwySetStatus();
            }
        }
        public AptBinding()
        {
            _RpuBinding= new List<RpuBinding>();
            _RwyBinding = new List<RwyBinding>();
        }
        public AptBinding(List<RpuBinding> rpubinding, List<RwyBinding> rwybinding)
        {
            _RpuBinding = new List<RpuBinding>(rpubinding);
            _RwyBinding = new List<RwyBinding>(rwybinding);
        }
    }
}
