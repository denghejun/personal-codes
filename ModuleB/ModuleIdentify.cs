﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DependencyService;

namespace ModuleB
{
    public class ModuleIdentify : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bar>().As<IBar>();
        }
    }
}
