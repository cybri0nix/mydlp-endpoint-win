﻿//    Copyright (C) 2011 Huseyin Ozgur Batur <ozgur@medra.com.tr>
//
//--------------------------------------------------------------------------
//    This file is part of MyDLP.
//
//    MyDLP is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    MyDLP is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with MyDLP.  If not, see <http://www.gnu.org/licenses/>.
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using MyDLP.EndPoint.Core;

namespace MyDLP.EndPoint.Service
{
    public class MainController
    {


        Engine engine;

        public static MainController GetInstance()
        {
            if (controller == null)
            {
                controller = new MainController();
            }
            return controller;
        }

        public void Start()
        {
            engine = new Engine();
            engine.Start();
            Logger.GetInstance().Debug("MyDLP-EP-Win started");
            if (Configuration.GetRegistryConf() == false)
            {
                Logger.GetInstance().Error("Unable to get configuration exiting!");
                //Environment.Exit(1);
            }
            else
            {
                Logger.GetInstance().Debug("MyDLP-EP-Win try to install mydlpmf");
                MyDLPEP.MiniFilterController.GetInstance().Start();
                Logger.GetInstance().Debug("MyDLP-EP-Win start finished");
                MyDLPEP.FilterListener.getInstance().StartListener();
            }

        }

        public void Stop()
        {
            MyDLPEP.MiniFilterController.GetInstance().Stop();
            Logger.GetInstance().Info("MyDLP-EP-Win stopped");
            engine.Stop();
        }

        private static MainController controller = null;
        private MainController() { }
    }
}
