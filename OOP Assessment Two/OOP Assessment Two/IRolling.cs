﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    public partial class IRolling : Component
    {
        public IRolling()
        {
            InitializeComponent();
        }

        public IRolling(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
