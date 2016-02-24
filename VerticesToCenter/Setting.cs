using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace VerticesToCenter
{
    public class VerticesToCenterSetting
    {

        public VerticesToCenterSetting()
        {
            //默认构造函数
            m_CenterSnap = true;
            m_KeySnapSwitch = Keys.ControlKey;
            m_PixelSnap = 4;
            m_SelectMod = EnumSelectMode.MostNearOne;
            m_PixelRadiusChangeLimit = 2;
            m_PixelMaxRadius = 500;
            m_MaxFeaturesSelect = 20;
        }
        public VerticesToCenterSetting(VerticesToCenterSetting toolSetting)
        {
            m_CenterSnap = toolSetting.CenterSnap;
            m_KeySnapSwitch = toolSetting.m_KeySnapSwitch;
            m_PixelSnap = toolSetting.m_PixelSnap;
            m_SelectMod = toolSetting.SelectMode;
            m_PixelRadiusChangeLimit = toolSetting.PixelRadiusChangeLimit;
            m_PixelMaxRadius = toolSetting.PixelMaxRadius;
            m_MaxFeaturesSelect = toolSetting.MaxFeaturesSelect;
        }
        private bool m_CenterSnap;
        public bool CenterSnap
        {
            get { return m_CenterSnap; }
            set { m_CenterSnap = value; }
        }
        public void UpdateCenterSnap(bool centerSnap)
        {
            m_CenterSnap = centerSnap;
        }

        private Keys m_KeySnapSwitch;
        public Keys KeySnapSwitch
        {
            get { return m_KeySnapSwitch; }
            set { m_KeySnapSwitch = value; }
        }
        public void UpdateKeySnapSwitch(Keys keySnapSwitch)
        {
            m_KeySnapSwitch = keySnapSwitch;
        }

        private int m_PixelSnap;
        public int PixelSnap
        {
            get { return m_PixelSnap; }
            set
            {
                if (value < 1)
                {
                    m_PixelSnap = 1;
                    return;
                }
                if (value > 10)
                {
                    m_PixelSnap = 10;
                    return;
                }
                m_PixelSnap = value;
            }
        }
        public void UpdatePixelSnap(int pixelSnap)
        {
            if (pixelSnap < 1)
            {
                m_PixelSnap = 1;
                return;
            }
            if (pixelSnap > 10)
            {
                m_PixelSnap = 10;
                return;
            }
            m_PixelSnap = pixelSnap;
        }

        private EnumSelectMode m_SelectMod;
        public EnumSelectMode SelectMode
        {
            get { return m_SelectMod; }
            set { m_SelectMod = value; }
        }
        public void UpdateSelectMode(EnumSelectMode selectMod)
        {
            m_SelectMod = selectMod;
        }

        private int m_PixelRadiusChangeLimit;
        public int PixelRadiusChangeLimit
        {
            get { return m_PixelRadiusChangeLimit; }
            set
            {
                if (value < 1)
                {
                    m_PixelRadiusChangeLimit = 1;
                    return;
                }
                if (value > 10)
                {
                    m_PixelRadiusChangeLimit = 10;
                    return;
                }
                m_PixelRadiusChangeLimit = value;

            }
        }
        public void UpdatePixelRadiusChangeLimit(int pixelRadiusChangeLimit)
        {
            if (pixelRadiusChangeLimit < 1)
            {
                m_PixelRadiusChangeLimit = 1;
                return;
            }
            if (pixelRadiusChangeLimit > 10)
            {
                m_PixelRadiusChangeLimit = 10;
                return;
            }
            m_PixelRadiusChangeLimit = pixelRadiusChangeLimit;

        }

        private int m_PixelMaxRadius;
        public int PixelMaxRadius
        {
            get { return m_PixelMaxRadius; }
            set
            {
                if (value < 100)
                {
                    m_PixelMaxRadius = 100;
                    return;
                }
                if (value > 1000)
                {
                    m_PixelMaxRadius = 1000;
                    return;
                }
                m_PixelMaxRadius = value;
            }
        }
        public void UpdatePixelMaxRadius(int pixelMaxRadius)
        {
            if (pixelMaxRadius < 100)
            {
                m_PixelMaxRadius = 100;
                return;
            }
            if (pixelMaxRadius > 1000)
            {
                m_PixelMaxRadius = 1000;
                return;
            }
            m_PixelMaxRadius = pixelMaxRadius;
        }

        private int m_MaxFeaturesSelect;
        public int MaxFeaturesSelect
        {
            get { return m_MaxFeaturesSelect; }
            set
            {
                if (value < 1)
                {
                    m_MaxFeaturesSelect = 1;
                    return;
                }
                if (value > 100)
                {
                    m_MaxFeaturesSelect = 100;
                    return;
                }
                m_MaxFeaturesSelect = value;
            }
        }
        public void UpdateMaxFeaturesSelect(int maxFeaturesSelect)
        {
            if (maxFeaturesSelect < 1)
            {
                m_MaxFeaturesSelect = 1;
                return;
            }
            if (maxFeaturesSelect > 100)
            {
                m_MaxFeaturesSelect = 100;
                return;
            }
            m_MaxFeaturesSelect = maxFeaturesSelect;
        }
    }

    public class DefaultVerticesToCenterSetting
    {
        public static bool CenterSnap
        {
            get { return true; }
        }

        public static Keys KeySnapSwitch
        {
            get { return Keys.ControlKey; }
        }

        public static int PixelSnap
        {
            get { return 4; }
        }

        public static EnumSelectMode SelectMode
        {
            get { return EnumSelectMode.MostNearOne; }
        }

        public static int PixelRadiusChangeLimit
        {
            get { return 2; }
        }

        public static int PixelMaxRadius
        {
            get { return 500; }

        }

        public static int MaxFeaturesSelect
        {
            get { return 20; }
        }

    }
}