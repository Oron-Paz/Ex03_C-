using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacture;
        public float m_MaxAirRecomended;
        public float m_CurrentPressure { get; set; }


        public string ManufactureName
        {
            get { return m_Manufacture; }
        }

        public float MaxAirRecomended
        {
            get { return m_MaxAirRecomended; }
        }
        public Wheel(string i_manufacture, float i_maxAirRecomended, float i_currentpreasure)
        {
            m_Manufacture = i_manufacture;
            m_MaxAirRecomended = i_maxAirRecomended;
            m_CurrentPressure = i_currentPressure;

        }
    }
}


