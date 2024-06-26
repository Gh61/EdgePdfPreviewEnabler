﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Gh61.EdgePdfPreviewEnabler.Localization;
using Gh61.EdgePdfPreviewEnabler.RegistryRules;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class ApplyRegistryRuleCommand : UICommandBase<RegistryRuleBase>
    {
        public static ApplyRegistryRuleCommand Instance { get; } = new ApplyRegistryRuleCommand();

        private readonly HashSet<RegistryRuleBase> _registeredRules = new HashSet<RegistryRuleBase>();

        private ApplyRegistryRuleCommand() : base(Resources.CommandApply)
        {
        }

        protected override void Execute(RegistryRuleBase rule)
        {
            ExecuteCore(rule);
        }

        public static void ExecuteCore(RegistryRuleBase rule)
        {
            try
            {
                rule.Apply();
                Thread.Sleep(100); // wait a little for registry to update and also for user experience
                DoEvents();
            }
            catch (Exception e)
            {
                MessageBox.Show(MainWindow.LastInstance, e.ToString(), e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            rule.Refresh();
        }

        protected override bool CanExecute(RegistryRuleBase rule)
        {
            if (_registeredRules.Add(rule))
            {
                rule.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(rule.IsFulfilled))
                    {
                        OnCanExecuteChanged();
                    }
                };
            }

            return CanExecuteCore(rule);
        }

        public static bool CanExecuteCore(RegistryRuleBase rule)
        {
            return !rule.IsFulfilled;
        }
    }
}
