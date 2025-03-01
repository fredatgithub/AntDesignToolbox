﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class BooleanPropertyViewModel : PropertyItemViewModel
    {
        public bool? DefaultValue { get; set; } = false;

        private bool? _value;
        public bool? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public override ICommand ResetCommand { get; set; }

        public BooleanPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { Value = DefaultValue; });
            Value = false;
        }

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            if(IgnoreOnDefault && DefaultValue == Value)
            {
                yield break;
            }
            if (Value == null)
            {
                yield break;
            }
            else
            {
                yield return new XAttribute(PropertyName, Value.ToString().ToLower());
            }
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            throw new NotImplementedException();
        }
    }
}
