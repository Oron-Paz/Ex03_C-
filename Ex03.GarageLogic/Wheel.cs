using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacture;
        private float m_MaxAirRecomended;
        public float m_CurrentPreasure { get; set; }


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
            m_CurrentPreasure = i_currentpreasure;

        }
        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentPreasure + i_AirToAdd <= m_MaxAirRecomended)
            {
                m_CurrentPreasure += i_AirToAdd;
            }
        }
    }
}


