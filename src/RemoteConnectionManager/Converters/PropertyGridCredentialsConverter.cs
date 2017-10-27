﻿using RemoteConnectionManager.Properties;
using RemoteConnectionManager.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Ioc;

namespace RemoteConnectionManager.Converters
{
    public class PropertyGridCredentialsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new ComboBoxItem { Content = Resources.Clear };
            }

            return SimpleIoc.Default.GetInstance<ViewModelLocator>()
                .Main.Credentials
                .Single(x => x.Credentials == value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CredentialsViewModel model)
            {
                return model.Credentials;
            }

            return null;
        }
    }
}
